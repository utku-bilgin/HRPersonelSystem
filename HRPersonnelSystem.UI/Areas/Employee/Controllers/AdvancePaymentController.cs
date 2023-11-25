using HRPersonnelSystem.UI.Areas.Employee.ImageHelpers;
using HRPersonnelSystem.UI.Areas.Employee.Models.AdvancePaymentDTOs;
using HRPersonnelSystem.UI.Areas.Employee.Models.EmployeeDTOs;
using HRPersonnelSystem.UI.Areas.Employee.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HRPersonnelSystem.UI.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class AdvancePaymentController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ImageHelper _imageHelper;

        public AdvancePaymentController(ImageHelper imageHelper)
        {
           
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://hrmanagementsystemapi.azurewebsites.net");
            _imageHelper = imageHelper;
        }

        // GET: AvancePaymentController

        // GET: AvancePaymentController/Details/5
        public async Task<ActionResult> UncertainAdvancePayment()
        {
           return await GetListOfAdvancePayment(ApprovalStatus.Bekleyen);
		}
		public async Task<ActionResult> ApprovedAdvancePayment()
		{
            return await GetListOfAdvancePayment(ApprovalStatus.Onaylandı);
		}
		public async Task<ActionResult> RejectedAdvancePayment()
		{
            return await GetListOfAdvancePayment(ApprovalStatus.Reddedildi);
		}
		// GET: AvancePaymentController/Create
		public ActionResult Create()
        {
            return View();
        }

        // POST: AvancePaymentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AdvancePaymentDTO advancePaymentRequestDTO)
        {
            try
            {
				advancePaymentRequestDTO.EmployeeId = Guid.Parse("7DB5918A-64B7-4D74-8D16-BB52FA969631");
				var responseTaskPay = await _httpClient.GetAsync("api/advancepayment");
                var readPay = responseTaskPay.Content.ReadAsAsync<List<AdvancePaymentDTO>>();
                var x = readPay.Result.Where(x => x.AdvancePaymentType == AdvancePaymentType.Bireysel);


                var responseTask = await _httpClient.GetAsync($"api/employee/7DB5918A-64B7-4D74-8D16-BB52FA969631");
                var readTask = responseTask.Content.ReadAsAsync<EmployeeEntity>();
                var readsalary = readTask.Result.Salary;
                if (advancePaymentRequestDTO.AdvancePaymentType == AdvancePaymentType.Kurumsal && advancePaymentRequestDTO.Amount > 100000)
                {
                    ModelState.AddModelError(string.Empty, "Avans ödemesi oluşturma başarısız oldu.");
                    return View(advancePaymentRequestDTO);
                }
                else if (advancePaymentRequestDTO.AdvancePaymentType == AdvancePaymentType.Bireysel)
                {
                    var MaxLimit = readsalary * 3;
                    if ((double)advancePaymentRequestDTO.Amount > MaxLimit)
                    {
                        ModelState.AddModelError(string.Empty, "Avans ödemesi oluşturma başarısız oldu.");
                        return View(advancePaymentRequestDTO);
                    }
                    else
                    {
                        if (x != null)
                        {
                            foreach (var item in x)
                            {
                                MaxLimit -= (double)item.Amount;
                            }
                            if ((double)advancePaymentRequestDTO.Amount > MaxLimit)
                            {
                                ModelState.AddModelError(string.Empty, "Avans ödemesi oluşturma başarısız oldu.");
                                return View(advancePaymentRequestDTO);
                            }
                        }
                    }
                }
                
                if (!ModelState.IsValid)
                {
                    return View(advancePaymentRequestDTO);
                }


                var postTask = await _httpClient.PostAsJsonAsync<AdvancePaymentDTO>("api/advancepayment", advancePaymentRequestDTO);


                if (postTask.IsSuccessStatusCode)
                {

                    return RedirectToAction(nameof(UncertainAdvancePayment));
                }
                else
                {

                    ModelState.AddModelError(string.Empty, "Avans ödemesi oluşturma başarısız oldu.");
                    return View(advancePaymentRequestDTO);
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, "Bir hata oluştu: " + ex.Message);
                return View(advancePaymentRequestDTO);
            }
        }


        // GET: AvancePaymentController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            var getTask = await _httpClient.GetAsync("api/advancepayment");
            var readTask = await getTask.Content.ReadAsAsync<List<AdvancePaymentDTO>>();
            AdvancePaymentDTO deleteDTO = readTask.FirstOrDefault(x => x.Id == id);

            return View(deleteDTO);
        }

        // POST: AvancePaymentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id, AdvancePaymentDTO advancePaymentDTO)
        {
            var postTask = await _httpClient.DeleteAsync($"api/advancepayment/{id}");
            //if (postTask.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            //{
            //    // HTTP 500 hatası alındığında daha fazla ayrıntı elde etmek için HttpResponse içeriğini alabilirsiniz.
            //    var errorContent = await postTask.Content.ReadAsStringAsync();
            //    return View(errorContent);

            //    // errorContent değişkenini günlüklerde veya hata sayfasında göstermek için kullanabilirsiniz.
            //}
            if (postTask.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(UncertainAdvancePayment));
            }

            else
            {
                return View();
            }
        }

        private async Task<ActionResult> GetListOfAdvancePayment(ApprovalStatus approvalStatus)
        {
			var responseTask = await _httpClient.GetAsync("api/advancepayment");
			if (responseTask.IsSuccessStatusCode)
			{
				var readTask = responseTask.Content.ReadAsAsync<List<AdvancePaymentDTO>>();
				var x = readTask.Result.Where(x => x.ApprovalStatus == approvalStatus);
				return View(x);
			}
            return View();
		}


    }
}

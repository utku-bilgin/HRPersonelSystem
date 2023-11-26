using HRPersonnelSystem.UI.Areas.CompanyDirector.Models.AdvancePaymentDTOs;
using HRPersonnelSystem.UI.Areas.CompanyDirector.Models.CompanyDirectorDTOs;
using HRPersonnelSystem.UI.Areas.CompanyDirector.Models.ExpenditureDTOs;
using HRPersonnelSystem.UI.Areas.CompanyDirector.Models.PermissionDTOs;
using HRPersonnelSystem.UI.Areas.Employee.Models.EmployeeDTOs;
using HRPersonnelSystem.UI.Areas.Employee.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;

namespace HRPersonnelSystem.UI.Areas.CompanyDirector.Controllers
{
    [Area("CompanyDirector")]
    public class OperationController : Controller
    {
        private readonly HttpClient _httpClient;

        public OperationController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7085");
        }

        //---------------------------------- ADVANCE ---------------------------------

        // GET: OperationController
        public async Task<ActionResult> AdvancePayment()
        {
            List<AdvancePaymentDTO> list = new List<AdvancePaymentDTO>();

            var userId = HttpContext.Session.GetString("UserId");
            var companyDirectorTask = await _httpClient.GetAsync($"api/CompanyDirector/{userId}");
            var companyDirector = await companyDirectorTask.Content.ReadAsAsync<CompanyDirectorDTO>();

            var responseTask = await _httpClient.GetAsync("api/advancepayment");
            if (responseTask.IsSuccessStatusCode)
            {
                var readTask = await responseTask.Content.ReadAsAsync<List<AdvancePaymentDTO>>();

                foreach (var item in readTask)
                {
                    var employeeTask = await _httpClient.GetAsync($"api/Employee/{item.EmployeeId}");
                    var employee = await employeeTask.Content.ReadAsAsync<EmployeeEntity>();

					item.FirstName = employee.FirstName;
					item.LastName = employee.LastName;
					item.Departman = employee.Department;

					if (companyDirector.CompanyId == employee.CompanyId)
                    {
                        list.Add(item);
                    }
                }

                return View(list);
            }

            return View();
        }  

		// GET: OperationController/Details/5
		public async Task<ActionResult> AdvancePaymentDetails(Guid id)
        {
			var responseTask = await _httpClient.GetAsync("api/advancepayment");
			if (responseTask.IsSuccessStatusCode)
			{
				var readTask = responseTask.Content.ReadAsAsync<List<AdvancePaymentDTO>>();
                var advancePayment = readTask.Result.FirstOrDefault(x=>x.Id == id);
                var employee = GetEmployeeById(advancePayment.EmployeeId);
                advancePayment = AdvanceMapFromEmployee(employee, advancePayment);
				return View(advancePayment);
			}
			return View();
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(AdvancePaymentDTO advancePaymentDTO, string buttonValue)
		{
			try
			{
				bool isTrue = buttonValue == "true";

				if (isTrue)
				{
                    advancePaymentDTO.ApprovalStatus = ApprovalStatus.Onaylandı;
                    advancePaymentDTO.DateOfReply = DateTime.Now;
					// Buton "True" olarak tıklandığında yapılacak işlemler burada.
				}
				else
				{
					advancePaymentDTO.ApprovalStatus = ApprovalStatus.Reddedildi;
					advancePaymentDTO.DateOfReply = DateTime.Now;
					// Buton "False" olarak tıklandığında yapılacak işlemler burada.
				}
				var putTask = await _httpClient.PutAsJsonAsync<AdvancePaymentDTO>("api/advancepayment", advancePaymentDTO);

				if (putTask.IsSuccessStatusCode)
				{
					return RedirectToAction(nameof(AdvancePayment));
				}
				else
				{
					return RedirectToAction(nameof(AdvancePayment));
				}
			}
			catch
			{
				return View(advancePaymentDTO);
			}
		}
		

        private  AdvancePaymentDTO AdvanceMapFromEmployee(Task<EmployeeEntity> employee,AdvancePaymentDTO advancePayment )
        {
			advancePayment.FirstName = employee.Result.FirstName;
			advancePayment.LastName = employee.Result.LastName;
			advancePayment.Departman = employee.Result.Department;
            return advancePayment;
		}
        //---------------------------------- ADVANCE ---------------------------------




        //---------------------------------- PERMISSION ---------------------------------
        // GET: OperationController
        public async Task<ActionResult> Permission()
        {
            List<PermissionDTO> list = new List<PermissionDTO>();

            var userId = HttpContext.Session.GetString("UserId");
            var companyDirectorTask = await _httpClient.GetAsync($"api/CompanyDirector/{userId}");
            var companyDirector = await companyDirectorTask.Content.ReadAsAsync<CompanyDirectorDTO>();

            var responseTask = await _httpClient.GetAsync("api/Permission");
            if (responseTask.IsSuccessStatusCode)
            {
                var readTask = await responseTask.Content.ReadAsAsync<List<PermissionDTO>>();

                foreach (var item in readTask)
                {
                    var employeeTask = await _httpClient.GetAsync($"api/Employee/{item.EmployeeId}");
                    var employee = await employeeTask.Content.ReadAsAsync<EmployeeEntity>();

					item.FirstName = employee.FirstName;
					item.LastName = employee.LastName;
					item.Department = employee.Department;

                    if (companyDirector.CompanyId == employee.CompanyId)
                    {
                        list.Add(item);
                    }
                }

                return View(list);
            }
            return View();
        }

        // GET: OperationController/Details/5
        public async Task<ActionResult> PermissionDetails(Guid id)
		{
			var responseTask = await _httpClient.GetAsync("api/Permission");
			if (responseTask.IsSuccessStatusCode)
			{
				var readTask = responseTask.Content.ReadAsAsync<List<PermissionDTO>>();
				var permission = readTask.Result.FirstOrDefault(x => x.Id == id);
				var employee = GetEmployeeById(permission.EmployeeId);
				permission = PermissionMapFromEmployee(employee, permission);
				return View(permission);
			}
			return View();
		}

		private PermissionDTO PermissionMapFromEmployee(Task<EmployeeEntity> employee, PermissionDTO permission)
		{
			permission.FirstName = employee.Result.FirstName;
			permission.LastName = employee.Result.LastName;
			permission.Department = employee.Result.Department;
			return permission;
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> EditPermission(PermissionDTO permission, string buttonValue)
		{
			try
			{
				bool isTrue = buttonValue == "true";

				if (isTrue)
				{
					permission.ApprovalStatus = ApprovalStatus.Onaylandı;
					permission.DateOfReply = DateTime.Now;
					// Buton "True" olarak tıklandığında yapılacak işlemler burada.
				}
				else
				{
					permission.ApprovalStatus = ApprovalStatus.Reddedildi;
					permission.DateOfReply = DateTime.Now;
					// Buton "False" olarak tıklandığında yapılacak işlemler burada.
				}
				var putTask = await _httpClient.PutAsJsonAsync<PermissionDTO>("api/Permission", permission);

				if (putTask.IsSuccessStatusCode)
				{
					return RedirectToAction(nameof(Permission));
				}
				else
				{
					return RedirectToAction(nameof(Permission));
				}
			}
			catch
			{
				return View(permission);
			}
		}

		//---------------------------------- PERMISSION ---------------------------------


		//---------------------------------- EXPENDITURE ---------------------------------

		// GET: OperationController
		public async Task<ActionResult> Expenditure()
		{
            List<ExpenditureDTO> list = new List<ExpenditureDTO>();//aşağıda şirket yöneticisi ve çalışanın şirket id lerine göre aynı şirkette çalışan kişileri çekmek için liste oluşturduk.

            var userId = HttpContext.Session.GetString("UserId");
            var companyDirectorTask = await _httpClient.GetAsync($"api/CompanyDirector/{userId}");//login yapan yöneticiyi id ye göre çektik
            var companyDirector = await companyDirectorTask.Content.ReadAsAsync<CompanyDirectorDTO>();

            var responseTask = await _httpClient.GetAsync("api/Expenditure");
			
			if(responseTask.IsSuccessStatusCode)
			{
				var readTask = await responseTask.Content.ReadAsAsync<List<ExpenditureDTO>>();
                
				foreach (var item in readTask)//okunan harcama bilgilerine göre içindeki elemanları döneriz.
                {
                    var employeeTask = await _httpClient.GetAsync($"api/Employee/{item.EmployeeId}");
                    var employee = await employeeTask.Content.ReadAsAsync<EmployeeEntity>();

					item.FirstName = employee.FirstName;
					item.LastName = employee.LastName;
					item.Department = employee.Department;

					if (companyDirector.CompanyId == employee.CompanyId)//döndüğümüz bu elemanlardan şirket yöneticisin ve çalışanın şirket id lerine göre eşleme yaparız ve şirket yöneticisiyle aynı şirkette çalışan çalışanın harcama taleplerini getiririz.
                    {
                        list.Add(item);
                    }
                }

                return View(list);
            }

			return View();
        }
 

        // GET: OperationController/Details/5
		public async Task<ActionResult> ExpenditureDetails(Guid id)
		{
			var responseTask=await _httpClient.GetAsync("api/Expenditure");
			if (responseTask.IsSuccessStatusCode)
			{
				var readTask = responseTask.Content.ReadAsAsync<List<ExpenditureDTO>>();
				var expenditure = readTask.Result.FirstOrDefault(x => x.Id == id);
				var employee = GetEmployeeById(expenditure.EmployeeId);
				expenditure = ExpenditureDTOMapFromEmployee(employee, expenditure);
				return View(expenditure);
			}
            return View();
		}


        private ExpenditureDTO ExpenditureDTOMapFromEmployee(Task<EmployeeEntity> employeeEntity, ExpenditureDTO expenditureDTO)
		{
			expenditureDTO.FirstName = employeeEntity.Result.FirstName;
			expenditureDTO.LastName= employeeEntity.Result.LastName;
			expenditureDTO.Department=employeeEntity.Result.Department;
			return expenditureDTO;
		}


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditExpenditure(ExpenditureDTO expenditureDTO, string buttonValue)
		{
			try
			{
				bool isTrue = buttonValue == "true";
				if (isTrue)
				{
					expenditureDTO.ApprovalStatus = ApprovalStatus.Onaylandı;
					expenditureDTO.DateOfReply=DateTime.Now;
				}
				else
				{
					expenditureDTO.ApprovalStatus = ApprovalStatus.Reddedildi;
					expenditureDTO.DateOfReply = DateTime.Now;
				}
				var putTask = await _httpClient.PutAsJsonAsync<ExpenditureDTO>("api/Expenditure", expenditureDTO);
				if (putTask.IsSuccessStatusCode)
				{
					return RedirectToAction(nameof(Expenditure));
				}
				else
				{
					return RedirectToAction(nameof(Expenditure));
				}

			}
			catch 
			{

				return View(expenditureDTO);
			}
		}

        //---------------------------------- EXPENDITURE ---------------------------------



        //-------------------------------- GET EMPLOYEE ID -------------------------------

        private async Task<EmployeeEntity> GetEmployeeById(Guid id)
        {
            var responseTask = await _httpClient.GetAsync($"api/employee/{id}");
            if (responseTask.IsSuccessStatusCode)
            {
                var readTask = responseTask.Content.ReadAsAsync<EmployeeEntity>();
                return readTask.Result;
            }
            else
            {
                return null;
            }
        }
        //-------------------------------- GET EMPLOYEE ID -------------------------------

    }
}

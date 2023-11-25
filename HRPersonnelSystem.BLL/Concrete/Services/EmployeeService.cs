using AutoMapper;
using HRPersonnelSystem.BLL.Abstract.IServices;
using HRPersonnelSystem.BLL.ImageHelpers;
using HRPersonnelSystem.Core.Enums;
using HRPersonnelSystem.DAL.UnitOfWorks;
using HRPersonnelSystem.Entities;
using HRPersonnelSystem.Models.DTOs.Employees;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HRPersonnelSystem.BLL.Concrete.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IPasswordResetService _passwordResetService;

        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper,  UserManager<AppUser> userManager, IPasswordResetService passwordResetService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _passwordResetService = passwordResetService;


        }

        public async Task<Employee> GetEmployeeIsActiveAsync(Guid id)
        {
            var employee = await _unitOfWork.GetRepository<Employee>().GetByIdAsync(id);
            return employee;
        }

        public async Task<Employee> UpdateEmployeeAsync(EmployeeUptadeDTO employeeUptadeDTO)
        {
            //var userEmail = _user.GetLoggedInEmail();
            var employee = await _unitOfWork.GetRepository<Employee>().GetAsync(x => x.IsActive && x.Id == employeeUptadeDTO.Id/*, i => i.Image*/);


            //if (employeeUptadeDTO.Photo != null)
            //{
            //    //_imageHelper.Delete(employee.Image.FileName);

            //    var imageUpload = await _imageHelper.Upload(employeeUptadeDTO.Id.ToString(), employeeUptadeDTO.Photo, ImageType.Employee);
            //    //Image image = new(imageUpload.FileName, employeeUptadeDTO.Photo.ContentType);

            //    //await _unitOfWork.GetRepository<Image>().AddAsync(image);
            //    //employee.ImageId = image.Id;
            //    employee.ImagePath = employeeUptadeDTO.Path;
            //}

            employee.ImagePath = employeeUptadeDTO.ImagePath;
            employee.Address = employeeUptadeDTO.Address;
            employee.PhoneNumber = employeeUptadeDTO.PhoneNumber;


            await _unitOfWork.GetRepository<Employee>().UpdateAsync(employee);
            await _unitOfWork.SaveAsync();

            return employee;


        }

        public async Task<List<EmployeeSummaryDTO>> GetAllEmployeIsActiveAsync()
        {
            var employe = await _unitOfWork.GetRepository<Employee>().GetAllAsync(x => x.IsActive);

            var map = _mapper.Map<List<EmployeeSummaryDTO>>(employe);
            return map;
        }

        public async Task<Employee> CreateEmployeeAsync(CreateEmployeeDTO createEmployeeDTO)
        {
           
            try
            {
                // başka bir çalışan var mı diye Id kontrolü
                bool isEmployeeExists = await _unitOfWork.GetRepository<Employee>().AnyAsync(e => e.Id == createEmployeeDTO.Id);

                if (isEmployeeExists)
                {
                    throw new Exception("Aynı kimlik (ID) değerine sahip bir çalışan zaten mevcut.");
                }

                //string companyName = createEmployeeDTO.CompanyName;
                //Company company = await _unitOfWork.GetRepository<Company>().SingleOrDefaultAsync(c => c.CompanyName == companyName);
                var company = await _unitOfWork.GetRepository<Company>()
                   .Where(c => c.CompanyName == createEmployeeDTO.CompanyName)
                   .Select(c => new Models.DTOs.CompanyDTOs.CompanyDtoForCompanyDirector
                   {
                       Id = c.Id,
                       CompanyName = c.CompanyName
                   })
                   .FirstOrDefaultAsync();

                if (company == null)
                {
                    throw new Exception("Belirtilen CompanyName ile eşleşen bir şirket bulunamadı.");
                }

                // Yeni çalışan oluşturma
                Employee employee = _mapper.Map<Employee>(createEmployeeDTO);
                employee.CompanyId= company.Id;
                employee.FirstName=createEmployeeDTO.FirstName;
                employee.LastName=createEmployeeDTO.LastName;
                employee.Gender = createEmployeeDTO.Gender;
                employee.TCNumber = createEmployeeDTO.TCNumber;
                employee.PhoneNumber = createEmployeeDTO.Phone;
               
                employee.Address = createEmployeeDTO.Address;
                employee.BirthPlace = createEmployeeDTO.BirthPlace;
                employee.Job= createEmployeeDTO.Job;
                employee.Department = createEmployeeDTO.Department;
                employee.Salary= createEmployeeDTO.Salary;
                employee.SecurityStamp = "1";
                employee.EmailConfirmed = true;
                employee.DateOfTermination = null;
                employee.PhoneNumberConfirmed = true;

                




                string generatedEmail = await _passwordResetService.GenerateEmailEmployee(createEmployeeDTO);
                employee.Email = generatedEmail;
                employee.NormalizedEmail = generatedEmail.ToUpper();
                employee.NormalizedUserName = generatedEmail.ToUpper();
                employee.UserName = generatedEmail;

                string generatedPassword = await _passwordResetService.GenerateRandomPasswordAsync();
                string salt = BCrypt.Net.BCrypt.GenerateSalt();
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(generatedPassword, salt);
                employee.PasswordHash = hashedPassword;

                await _unitOfWork.GetRepository<Employee>().AddAsync(employee);

                await _unitOfWork.SaveAsync();

                var passwordResetSuccess = await _passwordResetService.ResetEmployeePasswordAsync(employee.Id);

                if (passwordResetSuccess)
                {
                    // Random şifre oluşturuldu
                    var newPassword = await _passwordResetService.GenerateRandomPasswordAsync();

                    // E-posta gönderme işlemi
                    var emailSent = await _passwordResetService.SendPasswordResetEmailAsyncEmployee(createEmployeeDTO);

                    if (emailSent)
                    {
                        return employee;
                    }
                    else
                    {
                        throw new Exception("E-posta gönderme başarısız.");
                    }
                }
                else
                {
                    throw new Exception("Şifre sıfırlama başarısız.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Personel oluşturma başarısız: " + ex.Message);
            }
        }






    }
}


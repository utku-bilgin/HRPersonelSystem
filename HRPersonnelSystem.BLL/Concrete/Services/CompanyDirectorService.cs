using AutoMapper;
using HRPersonnelSystem.BLL.Abstract.IServices;
using HRPersonnelSystem.DAL.UnitOfWorks;
using HRPersonnelSystem.Entities;
using HRPersonnelSystem.Models.DTOs.CompanyDirectorDTOs;
using HRPersonnelSystem.Models.DTOs.CompanyDTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HRPersonnelSystem.BLL.Concrete.Services
{
    public class CompanyDirectorService : ICompanyDirectorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPasswordResetService _passwordResetService;
        private readonly UserManager<AppUser> _userManager;

        public CompanyDirectorService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<AppUser> userManager, IPasswordResetService passwordResetService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _passwordResetService = passwordResetService;
            _userManager = userManager;

        }

        public async Task<CompanyDirector> CreateDirectorAsync(CreateCompanyDirectorDTO createCompanyDirectorDTO)
        {
            try
            {
                // başka bir yönetici var mı diye Id kontrolü
                bool isEmployeeExists = await _unitOfWork.GetRepository<CompanyDirector>().AnyAsync(e => e.Id == createCompanyDirectorDTO.Id);

                if (isEmployeeExists)
                {
                    throw new Exception("Aynı kimlik (ID) değerine sahip bir çalışan zaten mevcut.");
                }

                // Şirket adını kullanarak Company Id'sini bulun
                //string companyName = createCompanyDirectorDTO.CompanyName;
                //Company company = await _unitOfWork.GetRepository<Company>().SingleOrDefaultAsync(c => c.CompanyName == companyName);


                var company = await _unitOfWork.GetRepository<Company>()
                    .Where(c => c.CompanyName == createCompanyDirectorDTO.CompanyName)
                    .Select(c => new CompanyDtoForCompanyDirector
                    {
                        Id = c.Id,
                        CompanyName = c.CompanyName
                    })
                    .FirstOrDefaultAsync();


                if (company == null)
                {
                    throw new Exception("Belirtilen CompanyName ile eşleşen bir şirket bulunamadı.");
                }

                // Yeni yönetici oluşturma
                CompanyDirector companyDirector = _mapper.Map<CompanyDirector>(createCompanyDirectorDTO);
                companyDirector.CompanyId = company.Id;
                companyDirector.PhoneNumber = createCompanyDirectorDTO.Phone;
                companyDirector.Address = createCompanyDirectorDTO.CompanyAddress;
                companyDirector.Department = createCompanyDirectorDTO.Departman;
                companyDirector.SecurityStamp = "1";
                companyDirector.EmailConfirmed = true;
                companyDirector.DateOfTermination = createCompanyDirectorDTO.DateOfTermination;
                companyDirector.DateOfHire = createCompanyDirectorDTO.DateOfHire;
                companyDirector.Gender = createCompanyDirectorDTO.Gender;
                companyDirector.PhoneNumberConfirmed = true;

                string generatedEmail = await _passwordResetService.GenerateEmail(createCompanyDirectorDTO);
                companyDirector.Email = generatedEmail;
                companyDirector.UserName = generatedEmail;
                companyDirector.NormalizedUserName = generatedEmail.ToUpper();
                companyDirector.NormalizedEmail = generatedEmail.ToUpper();

                string generatedPassword = await _passwordResetService.GenerateRandomPasswordAsync();
                string salt = BCrypt.Net.BCrypt.GenerateSalt();
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(generatedPassword, salt);
                companyDirector.PasswordHash = hashedPassword;

                await _unitOfWork.GetRepository<CompanyDirector>().AddAsync(companyDirector);

                await _unitOfWork.SaveAsync();

                // Şifreyi sıfırla ve e-postayla gönder
                var passwordResetSuccess = await _passwordResetService.ResetCompanyDirectorPasswordAsync(companyDirector.Id);

                if (passwordResetSuccess)
                {
                    // Random şifre oluşturuldu
                    var newPassword = await _passwordResetService.GenerateRandomPasswordAsync();

                    // E-posta gönderme işlemi
                    var emailSent = await _passwordResetService.SendPasswordResetEmailAsync(createCompanyDirectorDTO);

                    if (emailSent)
                    {
                        return companyDirector;
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

        public async Task<CompanyDirector> GetDirectorByIdAsync(Guid id)
        {
            try
            {
                CompanyDirector director = await _unitOfWork.GetRepository<CompanyDirector>().GetByIdAsync(id);
                return director;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<CompanyDirector> UpdateCompanyDirectorAsync(CompanyDirectorUpdateDTO companyDirectorUpdateDTO)
        {
            var companyDirector = await _unitOfWork.GetRepository<CompanyDirector>().GetAsync(x => x.IsActive && x.Id == companyDirectorUpdateDTO.Id);

            companyDirector.ImagePath = companyDirectorUpdateDTO.ImagePath;
            companyDirector.Address = companyDirectorUpdateDTO.Address;
            companyDirector.PhoneNumber = companyDirectorUpdateDTO.PhoneNumber;

            await _unitOfWork.GetRepository<CompanyDirector>().UpdateAsync(companyDirector);
            await _unitOfWork.SaveAsync();
            //var map=_mapper.Map<CompanyDirector>(companyDirectorUpdateDTO);
            return companyDirector;
        }
    }
}

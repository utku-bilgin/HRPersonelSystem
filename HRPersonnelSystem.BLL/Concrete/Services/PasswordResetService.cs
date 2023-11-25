using AutoMapper;
using HRPersonnelSystem.BLL.Abstract.IServices;
using HRPersonnelSystem.DAL.UnitOfWorks;
using HRPersonnelSystem.Entities;
using HRPersonnelSystem.Models.DTOs.CompanyDirectorDTOs;
using HRPersonnelSystem.Models.DTOs.Employees;
using MimeKit;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace HRPersonnelSystem.BLL.Concrete.Services
{
    public class PasswordResetService : IPasswordResetService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PasswordResetService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<string> GenerateRandomPasswordAsync()
        {
            const string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            char[] passwordChars = new char[8];

            for (int i = 0; i < 8; i++)
            {
                passwordChars[i] = allowedChars[random.Next(0, allowedChars.Length)];
            }

            return new string(passwordChars);
        }

        public async Task<bool> ResetCompanyDirectorPasswordAsync(Guid Id)
        {
            try
            {

                var user = await _unitOfWork.GetRepository<CompanyDirector>().GetByIdAsync(Id);

                if (user != null)
                {
                    // Yeni bir şifre oluşturun.
                    string newPassword = await GenerateRandomPasswordAsync();

                    // Şifreyi kullanıcının veritabanındaki kaydına güncelleyin.
                    user.PasswordHash = HashPassword(newPassword);

                    // Kullanıcının veritabanındaki kaydını güncelleyin.
                    await _unitOfWork.GetRepository<CompanyDirector>().UpdateAsync(user);

                    return true; // Şifre sıfırlama işlemi başarılı.
                }
                else
                {

                    return false; // Kullanıcı bulunamadı veya işlem başarısız.
                }
            }
            catch (Exception)
            {
                return false; // Şifre sıfırlama işlemi hatası.
            }
        }

       

        static string ConvertToEnglish(string text)
        {
            var turkishChars = new string[] { "ç", "ğ", "ı", "ö", "ş", "ü", "Ç", "Ğ", "İ", "Ö", "Ş", "Ü" };
            var englishChars = new string[] { "c", "g", "i", "o", "s", "u", "C", "G", "I", "O", "S", "U" };

            for (int i = 0; i < turkishChars.Length; i++)
            {
                text = text.Replace(turkishChars[i], englishChars[i]);
            }

            return text;
        }






        public string HashPassword(string password)
        {
            // Şifreyi güvenli bir şekilde hashleyin ve döndürün.
            return BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt());
        }

        public bool VerifyPassword(string hashedPassword, string password)
        {
            // Veritabanında saklanan hash ile kullanıcının girdiği şifreyi karşılaştırın.
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }

        


        public async Task<bool> SendPasswordResetEmailAsync(CreateCompanyDirectorDTO createCompanyDirectorDTO)
        {
            try
            {
                string email = await GenerateEmail(createCompanyDirectorDTO);
                string newPassword = await GenerateRandomPasswordAsync();  

                MimeMessage mimeMessage = new MimeMessage();
                MailboxAddress mailboxAddressFrom = new MailboxAddress("INKASIS", "esedasayar@gmail.com");
                MailboxAddress mailboxAddressTo = new MailboxAddress("Yönetici", email);



                mimeMessage.From.Add(mailboxAddressFrom);
                mimeMessage.To.Add(mailboxAddressTo);

               
               
                var bodyBuilder = new BodyBuilder();
                bodyBuilder.TextBody = $"Mail adresiniz: {email}\nOluşturulan şifreniz: {newPassword}\nŞifrenizi yenilemek için giriş yapın: https://hrmanagementsystem.azurewebsites.net?token={newPassword}";



                mimeMessage.Body = bodyBuilder.ToMessageBody();
                mimeMessage.Subject = "Şifre Yenileme";



                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Connect("smtp.gmail.com", 587, false);
                smtpClient.Authenticate("esedasayar@gmail.com", "uxnpkhktjqpjhfzz");
                smtpClient.Send(mimeMessage);
                smtpClient.Disconnect(true);



                return true; // E-posta başarıyla gönderildi.
            }
            catch (Exception)
            {
                return false; // E-posta gönderme hatası.
            }
        }

        public async Task<bool> ResetEmployeePasswordAsync(Guid Id)
        {
            try
            {

                var employee = await _unitOfWork.GetRepository<Employee>().GetByIdAsync(Id);

                if (employee != null)
                {
                    // Yeni bir şifre oluşturun.
                    string newPassword = await GenerateRandomPasswordAsync();

                    // Şifreyi kullanıcının veritabanındaki kaydına güncelleyin.
                    employee.PasswordHash = HashPassword(newPassword);

                    // Kullanıcının veritabanındaki kaydını güncelleyin.
                    await _unitOfWork.GetRepository<Employee>().UpdateAsync(employee);

                    return true; // Şifre sıfırlama işlemi başarılı.
                }
                else
                {

                    return false; // Kullanıcı bulunamadı veya işlem başarısız.
                }
            }
            catch (Exception)
            {
                return false; // Şifre sıfırlama işlemi hatası.
            }
        }

        public async Task<string> GenerateEmailEmployee(CreateEmployeeDTO createEmployeeDTO)
        {
            string firstName = ConvertToEnglish(createEmployeeDTO.FirstName.ToLower());
            string lastName = ConvertToEnglish(createEmployeeDTO.LastName.ToLower());

            // Şirket ismini boşluk karakterine göre ayır
            string[] companyWords = ConvertToEnglish(createEmployeeDTO.CompanyName).Split(' ');

            // İlk kelimeyi al
            string companyName = companyWords[0].ToLower();

            string email = $"{firstName}.{lastName}@bilgeadamboost.com";

            return email;
        }

        public async Task<string> GenerateEmail(CreateCompanyDirectorDTO createCompanyDirectorDTO)
        {
            string firstName = ConvertToEnglish(createCompanyDirectorDTO.FirstName.ToLower());
            string lastName = ConvertToEnglish(createCompanyDirectorDTO.LastName.ToLower());

            // Şirket ismini boşluk karakterine göre ayır
            string[] companyWords = ConvertToEnglish(createCompanyDirectorDTO.CompanyName).Split(' ');

            // İlk kelimeyi al
            string companyName = companyWords[0].ToLower();

            string email = $"{firstName}.{lastName}@{companyName}.com";

            return email;
        }

        public async Task<bool> SendPasswordResetEmailAsyncEmployee(CreateEmployeeDTO createEmployeeDTO)
        {
            try
            {
                string email = await GenerateEmailEmployee(createEmployeeDTO);
                string newPassword = await GenerateRandomPasswordAsync();

                MimeMessage mimeMessage = new MimeMessage();
                MailboxAddress mailboxAddressFrom = new MailboxAddress("INKASIS", "esedasayar@gmail.com");
                MailboxAddress mailboxAddressTo = new MailboxAddress("Employee", email);



                mimeMessage.From.Add(mailboxAddressFrom);
                mimeMessage.To.Add(mailboxAddressTo);

                

                var bodyBuilder = new BodyBuilder();
                bodyBuilder.TextBody = $"Mail adresiniz: {email}\nOluşturulan şifreniz: {newPassword}\nŞifrenizi yenilemek için giriş yapın: https://hrmanagementsystem.azurewebsites.net?token={newPassword}";



                mimeMessage.Body = bodyBuilder.ToMessageBody();
                mimeMessage.Subject = "Şifre yenileme";



                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Connect("smtp.gmail.com", 587, false);
                smtpClient.Authenticate("esedasayar@gmail.com", "uxnpkhktjqpjhfzz");
                smtpClient.Send(mimeMessage);
                smtpClient.Disconnect(true);



                return true; // E-posta başarıyla gönderildi.
            }
            catch (Exception)
            {
                return false; // E-posta gönderme hatası.
            }
        }
    }
}

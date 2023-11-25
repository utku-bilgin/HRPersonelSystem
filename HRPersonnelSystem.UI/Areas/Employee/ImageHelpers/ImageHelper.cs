using HRPersonnelSystem.UI.Areas.Employee.Models.Enums;
using HRPersonnelSystem.UI.Areas.Employee.Models.Images;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace HRPersonnelSystem.UI.Areas.Employee.ImageHelpers
{
    public class ImageHelper
    {
        private readonly string wwwroot;
        private readonly IHostEnvironment _env;
        private const string imgFolder = "images";

        public ImageHelper(IHostEnvironment env)
        {
            _env = env;
            //wwwroot = env.ContentRootPath;
            wwwroot = Path.Combine(env.ContentRootPath, "wwwroot");
        }

        private string ReplaceInvalidChars(string fileName)
        {
            string pattern = "[İıĞğÜüŞşÖöÇçé!'^+%/()=?_\\*æß@€<>#$½{}\\[\\]\\\\|~¨,;`.:\\s]";
            return Regex.Replace(fileName, pattern, "");
        }



        public async Task<ImageUpdateDto> Upload(string name, [FromForm] IFormFile imageFile, ImageType imageType)
        {
            //folderName ??= imageType == ImageType.User ? expenditureImagesFolder : employeeImagesFolder;

            if (!Directory.Exists(Path.Combine(wwwroot, imgFolder)))
                Directory.CreateDirectory(Path.Combine(wwwroot, imgFolder));

            string oldFileName = Path.GetFileNameWithoutExtension(imageFile.FileName);
            string fileExtension = Path.GetExtension(imageFile.FileName);

            name = ReplaceInvalidChars(name);

            DateTime dateTime = DateTime.Now;

            string newFileName = $"{name}_{dateTime.Millisecond}{fileExtension}";

            var path = Path.Combine(wwwroot, imgFolder, newFileName);

            using var stream = new FileStream(path, FileMode.Create);
            await imageFile.CopyToAsync(stream);
            await stream.FlushAsync();


            string message = imageType == ImageType.User
                ? $"{newFileName} isimli kullanıcı resmi başarı ile eklenmiştir."
                : $"{newFileName} isimli personel resmi başarı ile eklenmiştir";

            return new ImageUpdateDto()
            {
                ImagePath = $"{newFileName}"
            };
        }

        public void Delete(string imageName)
        {
            var fileToDelete = Path.Combine($"{wwwroot}/{imgFolder}/{imageName}");
            if (File.Exists(fileToDelete))
                File.Delete(fileToDelete);
        }
    }
}

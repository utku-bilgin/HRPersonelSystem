//using HRPersonnelSystem.Core.Enums;
//using HRPersonnelSystem.Models.DTOs.Images;
//using Microsoft.AspNetCore.Http;
//using Microsoft.Extensions.Hosting;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;

//namespace HRPersonnelSystem.BLL.ImageHelpers
//{
//	public class ImageHelper : IImageHelper
//	{
//		private readonly string wwwroot;
//		private readonly IHostEnvironment _env;
//		private const string imgFolder = "images";
//        private const string expenditureImagesFolder = "expenditure-images";
//        private const string employeeImagesFolder = "employee-images";


//		public ImageHelper(IHostEnvironment env)
//        {
//            _env = env;
//            //wwwroot = env.ContentRootPath;
//            wwwroot = Path.Combine(env.ContentRootPath, "wwwroot");
//        }

//		private string ReplaceInvalidChars(string fileName)
//		{
//			string pattern = "[İıĞğÜüŞşÖöÇçé!'^+%/()=?_\\*æß@€<>#$½{}\\[\\]\\\\|~¨,;`.:\\s]";
//			return Regex.Replace(fileName, pattern, "");
//		}



//        public async Task<ImageUpdateDto> Upload(string name, IFormFile imageFile, ImageType imageType, string folderName = null)
//        {
//            folderName ??= imageType == ImageType.User ? expenditureImagesFolder : employeeImagesFolder;

//            if (!Directory.Exists(Path.Combine(wwwroot, imgFolder, folderName)))
//                Directory.CreateDirectory(Path.Combine(wwwroot, imgFolder, folderName));

//            string oldFileName = Path.GetFileNameWithoutExtension(imageFile.FileName);
//            string fileExtension = Path.GetExtension(imageFile.FileName);

//            name = ReplaceInvalidChars(name);

//            DateTime dateTime = DateTime.Now;

//            string newFileName = $"{name}_{dateTime.Millisecond}{fileExtension}";

//            var path = Path.Combine(wwwroot, imgFolder, folderName, newFileName);

//            using var stream = new FileStream(path, FileMode.Create);
//            await imageFile.CopyToAsync(stream);
//            await stream.FlushAsync();


//            string message = imageType == ImageType.User
//                ? $"{newFileName} isimli kullanıcı resmi başarı ile eklenmiştir."
//                : $"{newFileName} isimli personel resmi başarı ile eklenmiştir";

//            return new ImageUpdateDto()
//            {
//                FileName = $"{folderName}/{newFileName}"
//            };
//        }

//        public void Delete(string imageName)
//        {
//            var fileToDelete = Path.Combine($"{wwwroot}/{imgFolder}/{imageName}");
//            if (File.Exists(fileToDelete))
//                File.Delete(fileToDelete);
//        }
//    }
//}

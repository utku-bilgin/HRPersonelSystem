using HRPersonnelSystem.Core.BaseEntities;
using HRPersonnelSystem.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPersonnelSystem.Entities
{
    public class Image : BaseEntity
    {
		public Image(string fileName, string fileType, ImageType imageType)
		{
			FileName = fileName;
			FileType = fileType;
            ImageType = imageType;
		}
        public Image()
        {
            
        }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string? ImagePath { get; set; }

        public ImageType ImageType { get; set; }

        
        //public virtual Employee Employee { get; set; }
        //public virtual  Expenditure Expenditure{ get; set; }
        //public virtual AdvancePayment AdvancePayment { get; set; }


    }
}

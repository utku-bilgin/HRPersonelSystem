using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPersonnelSystem.UI.Areas.Employee.Models.Enums
{
    public enum ImageType { User=0,Employee=1,CompanyDirector=2};
    public enum PermissionType
    {
        Askerlik = 0,
        Babalık = 1,
        Doğum = 2,
        Evlilik = 3,
        Hastalık = 4,
        Mazeret = 5,
        Refakat = 6,
        Yıllık = 7
    };

    public enum ApprovalStatus
    {
        Onaylandı,
        Reddedildi,
        Bekleyen

    };

    public enum CurrencyUnit
    {
        TL=0,
        USD=1,
        EUR=2,        
        CAD=3,
        GBP=4,
    };
    public enum AdvancePaymentType
    {
		Bireysel = 1,
		Kurumsal =0
        
    };
    public enum ExpenditureType
    {        
        Etkinlik=0,
        İletişim=1,
        İş=2,
        Konaklama=3,
        Seyahat=4,
        Yemek=5,
        Diğer=6,

    };
    public enum Gender
    {
        Kadın,
        Erkek
    };
}

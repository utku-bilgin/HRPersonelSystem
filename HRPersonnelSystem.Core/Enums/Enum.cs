using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPersonnelSystem.Core.Enums
{
    public enum ImageType { User=0,Employee=1};
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
		USD,
		EUR,
		TL,
		CAD,
		GBP,
	};
	public enum AdvancePaymentType
	{
		Kurumsal,
		Bireysel
	};
	public enum ExpenditureType
	{
        Etkinlik = 0,
        İletişim = 1,
        İş = 2,
        Konaklama = 3,
        Seyahat = 4,
        Yemek = 5,
        Diğer = 6,
    };
	public enum Gender
	{
		Kadın,
		Erkek
	};
}

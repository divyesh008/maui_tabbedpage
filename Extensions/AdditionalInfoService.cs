using System;
namespace TabedPageDemo.Extensions
{
	public class AdditionalInfoService : IAdditionalInfoService
    {
        public List<MobileAdditionalInfo> GetDummyAdditionalInfoService()
        {
            return new List<MobileAdditionalInfo>()
            {
                new MobileAdditionalInfo()
                {
                    WaterSupply = "Public",
                    Sewage = "Public",
                    WIERSNumber = "702AUS0001462",
                    NumberOfMobileVendors = "1",
                    ExemptReason = "Non-Exempt",
                }
                 
            };
        }
    }
}


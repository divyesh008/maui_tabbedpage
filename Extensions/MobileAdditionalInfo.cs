using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace TabedPageDemo.Extensions
{
	public class MobileAdditionalInfo : INotifyPropertyChanged
    {
        [JsonProperty("WaterSupply")]
        public string WaterSupply { get; set; }
        [JsonProperty("Sewage")]
        public string Sewage { get; set; }
        [JsonProperty("WIERSNumber")]
        public string WIERSNumber { get; set; }
        [JsonProperty("NumberOfMobileVendors")]
        public string NumberOfMobileVendors { get; set; }
        [JsonProperty("ExemptReason")]
        public string ExemptReason { get; set; }


        public MobileAdditionalInfo(string waterSupply, string sewage, string wiersNumber, string numberOfMobileVendors, string exemptReason)
        {
            WaterSupply = waterSupply;
            Sewage = sewage;
            WIERSNumber = wiersNumber;
            NumberOfMobileVendors = numberOfMobileVendors;
            ExemptReason = exemptReason;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public MobileAdditionalInfo()
		{

		}
	}
}


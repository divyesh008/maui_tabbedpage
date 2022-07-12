using System;
using System.Diagnostics;
using CommunityToolkit.Maui.Alerts;
using Microsoft.Extensions.Logging;
using MvvmHelpers;
using TabedPageDemo.Extensions;

namespace TabedPageDemo.ViewModels
{
    public class AdditionalInfoPageViewModel : BaseViewModel
    {

        private readonly ILogger<AdditionalInfoPageViewModel> _logger;

        private readonly IAdditionalInfoService _additionalInfoService;


        #region Text 
        private const string GeneralUILableText = "General";
        private string _generalLableText = GeneralUILableText;
        public string GeneralLableText
        {
            get { return _generalLableText; }
            set { SetProperty(ref _generalLableText, value); }
        }

        private const string WaterSupplyUILableText = "Water Supply";
        private string _waterSupplyLableText = WaterSupplyUILableText;
        public string WaterSupplyLableText
        {
            get { return _waterSupplyLableText; }
            set { SetProperty(ref _waterSupplyLableText, value); }
        }

        private const string SewageUILableText = "Sewage";
        private string _sewageUILableText = SewageUILableText;
        public string SewageLableText
        {
            get { return _sewageUILableText; }
            set { SetProperty(ref _sewageUILableText, value); }
        }

        private const string WIERSNumberUILableText = "WIERS number";
        private string _wiersNumberLableText = SewageUILableText;
        public string WIERSNumberLableText
        {
            get { return _wiersNumberLableText; }
            set { SetProperty(ref _wiersNumberLableText, value); }
        }


        private const string NumberOfVendorsUILableText = "Number of mobile vendors";
        private string _numberOfVendorsUILableText = NumberOfVendorsUILableText;
        public string NumberOfVendorsLableText
        {
            get { return _numberOfVendorsUILableText; }
            set { SetProperty(ref _numberOfVendorsUILableText, value); }
        }

        private const string ExemptReasonUILableText = "Exempt reason";
        private string _exemptReasonUILableText = ExemptReasonUILableText;
        public string ExemptReasonLableText
        {
            get { return _exemptReasonUILableText; }
            set { SetProperty(ref _exemptReasonUILableText, value); }
        }

        private const string OnBeginInspectionText = "Begin Inspection";
        private string _beginInspectionButtonText = OnBeginInspectionText;
        public string BeginInspectionButtonText
        {
            get { return _beginInspectionButtonText; }
            set { SetProperty(ref _beginInspectionButtonText, value); }
        }

        #endregion

        #region UI Binding 
        private string _waterSupply;
        public string WaterSupplyType
        {
            get { return _waterSupply; }
            set
            {
                _waterSupply = value;
                OnPropertyChanged("WaterSupplyType");
            }
        }

        private string _sewage;
        public string SewageType
        {
            get { return _sewage; }
            set
            {
                _sewage = value;
                OnPropertyChanged("SewageType");
            }
        }

        private string _wiersNumber;
        public string WIERSNumber
        {
            get { return _wiersNumber; }
            set
            {
                _wiersNumber = value;
                OnPropertyChanged("WIERSNumber");
            }
        }

        private string _numberOfMobileVendors;
        public string NumberOfMobileVendors
        {
            get { return _numberOfMobileVendors; }
            set
            {
                _numberOfMobileVendors = value;
                OnPropertyChanged("NumberOfMobileVendors");
            }
        }

        private string _exemptReason;
        public string ExemptReason
        {
            get { return _exemptReason; }
            set
            {
                _exemptReason = value;
                OnPropertyChanged("ExemptReason");
            }
        }

        #endregion

        //Session error message 
        private string _sessionErrorMessage;
        public string SessionErrorMessage
        {
            get { return _sessionErrorMessage; }
            set { SetProperty(ref _sessionErrorMessage, value); }
        }

        #region Commands 
        public Command BeginInspectionCommand { get; private set; }
        #endregion

        #region Constructor
        public AdditionalInfoPageViewModel()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            var toast = Toast.Make("Additional Info Page ");
            toast.Show(cancellationTokenSource.Token);

        }
        public AdditionalInfoPageViewModel(ILogger<AdditionalInfoPageViewModel> logger)
        {
            _logger = logger;

            //UI Text Fields
            #region
            GeneralLableText = GeneralUILableText;
            WaterSupplyLableText = WaterSupplyUILableText;
            SewageLableText = SewageUILableText;
            WIERSNumberLableText = WIERSNumberUILableText;
            NumberOfVendorsLableText = NumberOfVendorsUILableText;
            ExemptReasonLableText = ExemptReasonUILableText;
            BeginInspectionButtonText = OnBeginInspectionText;
            #endregion

            //BeginInspectionCommand = commandService.CreateAsyncCommand(OnBeginInspection);

            GetAdditionalInfo();
        }
        #endregion


        //Call the WEBApi and consume the response 
        public void GetAdditionalInfo()
        {
            try
            {
                //TODO
                if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                {
                    //IsBusy=true;

                    // MobileAdditionalInfo[] response = (MobileAdditionalInfo[]);

                    var response = _additionalInfoService.GetDummyAdditionalInfoService();
                    if (response != null)
                    {
                        WaterSupplyType = response[0].WaterSupply;
                        SewageType = response[0].Sewage;
                        WIERSNumber = response[0].WIERSNumber;
                        NumberOfMobileVendors = response[0].NumberOfMobileVendors;
                        ExemptReason = response[0].ExemptReason;
                    }
                    Console.WriteLine("AdditionalInfo service response :-" + response.ToList());
                }
                else
                {
                    SessionErrorMessage = "Internet Access is required";
                    BeginInspectionButtonText = "";
                    return;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(" Get Additional Info causing the exception " + ex);
            }
            finally
            {
                //IsBusy= false;
            }


        }
        private async Task OnBeginInspection()
        {
            Debug.WriteLine($"OnBeginInspection() command received:{DateTime.Now} ");
            SessionErrorMessage = string.Empty;
            // IsBusy= true;
            try
            {
                if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                {
                    BeginInspectionButtonText = "Inspection started...";
                    await OnInspectionBegin();
                }
                else
                {
                    SessionErrorMessage = "Login Failed: Internet Access is required";
                    BeginInspectionButtonText = OnBeginInspectionText;
                    return;
                }
            }
            catch (Exception ex)
            {
                SessionErrorMessage = ex.Message;
                Debug.WriteLine($"ERROR: OnBeginInspection() {ex.Message} ");
            }
            //finally()
            //{
            // IsBusy= false;
            //}
        }

        //TODO Update the actual page 
        private async Task OnInspectionBegin()
        {
            _logger.LogInformation("User is started Inspection.  Initializing Inspection.");
            //await Shell.Current.GoToAsync(nameof());
        }
    }

}


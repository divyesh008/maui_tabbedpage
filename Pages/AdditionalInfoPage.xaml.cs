using TabedPageDemo.ViewModels;

namespace TabedPageDemo.Pages;

public partial class AdditionalInfoPage : ContentPage
{
    public AdditionalInfoPage()
    {
        InitializeComponent();
    }

    public AdditionalInfoPage(AdditionalInfoPageViewModel viewModel)
    {

        this.BindingContext = viewModel;
    }
}

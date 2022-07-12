using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;

namespace TabedPageDemo.Pages;
public partial class CategoryPage : Microsoft.Maui.Controls.TabbedPage
{
	public CategoryPage()
	{
		InitializeComponent();

		On<iOS>().SetUseSafeArea(true);

    }
}

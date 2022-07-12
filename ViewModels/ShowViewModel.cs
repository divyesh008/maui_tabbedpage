using System;
using TabedPageDemo.Pages;
using CommonBasicStandardLibraries.MVVMFramework.ViewModels;
using TabedPageDemo.Extensions;
using MvvmHelpers;

namespace TabedPageDemo.ViewModels
{
    public class ShowViewModel : BaseViewModel
    { 
        public Show Show { get; set; }

        public ShowViewModel(Show show, bool isSubscribed)
        {
            Show = show;
        }

        private Task NavigateToDetailCommandExecute() => Shell.Current.GoToAsync($"{nameof(ShowDetailPage)}");

        public ShowViewModel()
		{

		}
	}
}


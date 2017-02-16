using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using XFDoggy.Helps;
using System.Threading.Tasks;

namespace XFDoggy.ViewModels
{
    public class LoadingPageViewModel : BindableBase, INavigationAware
    {

        private readonly INavigationService _navigationService;
        public LoadingPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            await Task.Delay(500);
            var fooI = (await AppData.DataService.GetTravelExpensesCategoryAsync()).ToList();
            AppData.AllTravelExpensesCategory = fooI;
            await Task.Delay(500);

            await _navigationService.NavigateAsync("xf:///LoginPage");
        }
    }
}

using Xamarin.Forms;
using XFDoggy.Helps;
using XFDoggy.ViewModels;
using System.Linq;
using System;

namespace XFDoggy.Views
{
    public partial class TravelExpensesPage : ContentPage
    {
        TravelExpensesPageViewModel fooTravelExpensesPageViewModel;
        public TravelExpensesPage()
        {
            InitializeComponent();

            fooTravelExpensesPageViewModel = this.BindingContext as TravelExpensesPageViewModel;
            設定Picker選單內容();
            fooTravelExpensesPageViewModel.foo讀取Picker選擇項目 = 讀取Picker選擇項目;
            fooTravelExpensesPageViewModel.foo分類Picker初始化 = Picker資料初始化;
            fooTravelExpensesPageViewModel.foo頁面Title初始化 = 頁面Title初始化;
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        private void 頁面Title初始化(string obj)
        {
            this.Title = obj;
        }

        public void 設定Picker選單內容()
        {
            foreach (var item in AppData.AllTravelExpensesCategory)
            {
                picker分類.Items.Add(item.Name);
            }
        }

        public string 讀取Picker選擇項目()
        {
            string fooRet = "";
            var fooIdx = picker分類.SelectedIndex;
            if (fooIdx >= 0)
            {
                fooRet = picker分類.Items[fooIdx];
            }
            else
            {
                fooRet = "";
            }
            return fooRet;
        }

        public void Picker資料初始化(string category)
        {
            var fooItem = AppData.AllTravelExpensesCategory.FirstOrDefault(x => x.Name == category);
            if(fooItem != null)
            {
                var fooIdx = AppData.AllTravelExpensesCategory.IndexOf(fooItem);
                if (fooIdx >= 0)
                {
                    picker分類.SelectedIndex = fooIdx;
                }
            }
        }
    }
}

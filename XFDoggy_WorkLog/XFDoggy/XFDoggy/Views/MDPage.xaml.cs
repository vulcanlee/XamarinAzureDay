using Xamarin.Forms;
using XFDoggy.ViewModels;

namespace XFDoggy.Views
{
    public partial class MDPage : MasterDetailPage
    {
        MDPageViewModel fooMDPageViewModel;
        public MDPage()
        {
            InitializeComponent();

            fooMDPageViewModel = this.BindingContext as MDPageViewModel;
        }

        public override bool ShouldShowToolbarButton()
        {
            base.ShouldShowToolbarButton();
            // 這裡設定要在導航工具列上隱藏漢堡按鈕
            return fooMDPageViewModel.漢堡按鈕顯示;
        }
    }
}
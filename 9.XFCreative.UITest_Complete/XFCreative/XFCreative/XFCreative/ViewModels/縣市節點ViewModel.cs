using Prism.Mvvm;

namespace XFCreative.ViewModels
{
    public class 縣市節點ViewModel : BindableBase
    {
        #region 縣市
        private string _縣市;
        public string 縣市
        {
            get { return _縣市; }
            set { SetProperty(ref _縣市, value); }
        }
        #endregion
    }
}
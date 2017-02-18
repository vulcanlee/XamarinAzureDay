using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using XFDoggy.Models;

namespace XFDoggy.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        #region Repositories (遠端或本地資料存取)
        #endregion

        #region ViewModel Property (用於在 View 中作為綁定之用)

        #region Title
        private string _Title;
        /// <summary>
        /// Title
        /// </summary>
        public string Title
        {
            get { return this._Title; }
            set { this.SetProperty(ref this._Title, value); }
        }
        #endregion

        #region Xamarin學習資源清單
        private ObservableCollection<Xamarin學習資源項目ViewModel> _Xamarin學習資源清單 = new ObservableCollection<Xamarin學習資源項目ViewModel>();
        /// <summary>
        /// Xamarin學習資源清單
        /// </summary>
        public ObservableCollection<Xamarin學習資源項目ViewModel> Xamarin學習資源清單
        {
            get { return _Xamarin學習資源清單; }
            set { SetProperty(ref _Xamarin學習資源清單, value); }
        }
        #endregion

        #region Xamarin學習資源Picker清單
        private ObservableCollection<string> _Xamarin學習資源Picker清單 = new ObservableCollection<string>();
        /// <summary>
        /// Xamarin學習資源Picker清單
        /// </summary>
        public ObservableCollection<string> Xamarin學習資源Picker清單
        {
            get { return _Xamarin學習資源Picker清單; }
            set { SetProperty(ref _Xamarin學習資源Picker清單, value); }
        }
        #endregion

        #region Xamarin學習資源選擇項目
        private string _Xamarin學習資源選擇項目;
        /// <summary>
        /// Xamarin學習資源選擇項目
        /// </summary>
        public string Xamarin學習資源選擇項目
        {
            get { return this._Xamarin學習資源選擇項目; }
            set { this.SetProperty(ref this._Xamarin學習資源選擇項目, value); }
        }
        #endregion

        #region 顯示網頁的URL
        private string _顯示網頁的URL;
        /// <summary>
        /// 顯示網頁的URL
        /// </summary>
        public string 顯示網頁的URL
        {
            get { return this._顯示網頁的URL; }
            set { this.SetProperty(ref this._顯示網頁的URL, value); }
        }
        #endregion


        #endregion

        #region Field 欄位

        public DelegateCommand Xamarin學習資源選擇項目Command { get; set; }

        #endregion

        #region Constructor 建構式
        public MainPageViewModel()
        {
            #region 頁面中綁定的命令
            Xamarin學習資源選擇項目Command = new DelegateCommand(() =>
            {
                var fooObject = Xamarin學習資源清單.FirstOrDefault(x => x.名稱 == Xamarin學習資源選擇項目);
                if (fooObject != null)
                {
                    顯示網頁的URL = fooObject.URL;
                }
            });
            #endregion
        }
        #endregion

        #region Navigation Events (頁面導航事件)
        #endregion

        #region 設計時期或者執行時期的ViewModel初始化
        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"];

            #region 進行選單項目資料初始化
            Xamarin學習資源清單.Clear();
            Xamarin學習資源清單.Add(new Xamarin學習資源項目ViewModel
            {
                名稱 = "Xamarin 教育訓練課程",
                URL = "https://www.accupass.com/org/detail/r/1507090942441281249650/1/0"
            });
            Xamarin學習資源清單.Add(new Xamarin學習資源項目ViewModel
            {
                名稱 = "Xamarin實驗室部落格",
                URL = "https://mylabtw.blogspot.com/"
            });
            Xamarin學習資源清單.Add(new Xamarin學習資源項目ViewModel
            {
                名稱 = "Xamarin實驗室粉絲團",
                URL = "https://www.facebook.com/vulcanlabtw/"
            });

            Xamarin學習資源Picker清單.Clear();
            foreach (var item in Xamarin學習資源清單)
            {
                Xamarin學習資源Picker清單.Add(item.名稱);
            }

            var fooItem = Xamarin學習資源清單[0];
            Xamarin學習資源選擇項目 = Xamarin學習資源Picker清單[0];
            顯示網頁的URL = fooItem.URL;
            #endregion
        }
        #endregion

        #region 相關事件
        #endregion

        #region 相關的Command定義
        #endregion

        #region 其他方法
        #endregion


    }
}

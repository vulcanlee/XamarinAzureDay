using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using XFDoggy.Helps;

namespace XFDoggy.ViewModels
{
    public class MainMDPageViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;


        #region 差旅費用申請Color
        private Color _差旅費用申請Color;
        /// <summary>
        /// 差旅費用申請
        /// </summary>
        public Color 差旅費用申請Color
        {
            get { return this._差旅費用申請Color; }
            set { this.SetProperty(ref this._差旅費用申請Color, value); }
        }
        #endregion

        #region 登出Color
        private Color _登出Color;
        /// <summary>
        /// 登出
        /// </summary>
        public Color 登出Color
        {
            get { return this._登出Color; }
            set { this.SetProperty(ref this._登出Color, value); }
        }
        #endregion


        public DelegateCommand 差旅費用申請Command { get; private set; } 
        public DelegateCommand 登出Command { get; private set; } 

        public MainMDPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            差旅費用申請Command = new DelegateCommand(差旅費用申請);
            登出Command = new DelegateCommand(登出);

            更新正在執行項目的顏色();
        }

        private async void 登出()
        {
            AppData.正在執行功能 = 執行功能列舉.登出;
            更新正在執行項目的顏色();
            await _navigationService.NavigateAsync("xf:///LoginPage");
        }

        private async void 差旅費用申請()
        {
            if (AppData.正在執行功能 != 執行功能列舉.差旅費用申請)
            {
                AppData.正在執行功能 = 執行功能列舉.差旅費用申請;
                更新正在執行項目的顏色();
                await _navigationService.NavigateAsync("xf:///MainMDPage/NaviPage/TravelExpensesListPage");
            }
        }

        public void 更新正在執行項目的顏色()
        {
            清除所有功能的顏色設定();
            switch (AppData.正在執行功能)
            {
                case 執行功能列舉.差旅費用申請:
                    差旅費用申請Color = Color.FromHex("ed6d45");
                    break;
                case 執行功能列舉.登出:
                    登出Color = Color.FromHex("ed6d45");
                    break;
                default:
                    break;
            }
        }

        public void 清除所有功能的顏色設定()
        {
            差旅費用申請Color = Color.FromHex("040000");
            登出Color = Color.FromHex("040000");
        }
    }
}

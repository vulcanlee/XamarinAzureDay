using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFDoggy.Models;
using XFDoggy.Services;

namespace XFDoggy.Helps
{
    public class AppData
    {
        public static string UserUrl { get; set; } = "http://xamarindoggy.azurewebsites.net/api/user";
        public static string TravelExpensesCategoryUrl { get; set; } = "http://xamarindoggy.azurewebsites.net/api/TravelExpensesCategory";
        public static string UserAuthUrl { get; set; } = "http://xamarindoggy.azurewebsites.net/api/User/Auth";
        //public static string TravelExpenseGetUrl { get; set; } = "http://xamarindoggy.azurewebsites.net/api/TravelExpense?account=";
        public static string TravelExpenseUrl { get; set; } = "http://xamarindoggy.azurewebsites.net/api/TravelExpense";
        public static DataService DataService = new DataService();
        public static List<TravelExpense> AllTravelExpense = new List<TravelExpense>();
        public static List<TravelExpensesCategory> AllTravelExpensesCategory = new List<TravelExpensesCategory>();
        public static string Account = "";

        public static 執行功能列舉 正在執行功能 = 執行功能列舉.差旅費用申請;

    }

    public enum 執行功能列舉
    {
        差旅費用申請,
        登出,
    }
}

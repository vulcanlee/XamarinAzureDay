using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XFWebAPI.Models;

namespace XFWebAPI.DAL
{
    public class DoggyInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DoggyContext>
    {
        protected override void Seed(DoggyContext context)
        {
            #region 差旅類別紀錄初始化
            var TravelExpensesCategories = new List<TravelExpensesCategory>
            {
            new TravelExpensesCategory { Name="交通費"},
            new TravelExpensesCategory { Name="住宿費"},
            new TravelExpensesCategory { Name="應酬費"},
            new TravelExpensesCategory { Name="業務費"},
            new TravelExpensesCategory { Name="差伙食"},
            };

            TravelExpensesCategories.ForEach(s => context.TravelExpensesCategory.Add(s));
            context.SaveChanges();
            #endregion

            #region 使用者記錄初始化
            var Users = new List<User>
            {
            new User { Account="001", Password="901"},
            new User { Account="002", Password="902"},
            new User { Account="003", Password="903"},
            new User { Account="004", Password="904"},
            new User { Account="005", Password="905"},
            new User { Account="006", Password="906"},
            new User { Account="007", Password="907"},
            new User { Account="008", Password="908"},
            new User { Account="009", Password="909"},
            new User { Account="010", Password="910"},
            new User { Account="011", Password="911"},
            new User { Account="012", Password="912"},
            new User { Account="013", Password="913"},
            new User { Account="014", Password="914"},
            new User { Account="015", Password="915"},
            new User { Account="016", Password="916"},
            new User { Account="017", Password="917"},
            new User { Account="018", Password="918"},
            new User { Account="019", Password="919"},
            new User { Account="020", Password="920"},
            new User { Account="021", Password="921"},
            new User { Account="022", Password="922"},
            new User { Account="023", Password="923"},
            new User { Account="024", Password="924"},
            new User { Account="025", Password="925"},
            new User { Account="026", Password="926"},
            new User { Account="027", Password="927"},
            new User { Account="028", Password="928"},
            new User { Account="029", Password="929"},
            new User { Account="030", Password="930"},
            };

            Users.ForEach(s => context.User.Add(s));
            context.SaveChanges();
            #endregion
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using XFWebAPI.Models;

namespace XFWebAPI.DAL
{
    public class DoggyContext : DbContext
    {

        public DoggyContext() : base("DoggyContext")
        {
        }

        public DbSet<TravelExpense> TravelExpense { get; set; }
        public DbSet<TravelExpensesCategory> TravelExpensesCategory { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
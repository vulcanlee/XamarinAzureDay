﻿using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Tables;
using XamarinAzureDayService.DataObjects;

namespace XamarinAzureDayService.Models
{
    public class XamarinAzureDayContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to alter your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        private const string connectionStringName = "Name=MS_TableConnectionString";

        public XamarinAzureDayContext() : base(connectionStringName)
        {
        } 

        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(
                new AttributeToColumnAnnotationConvention<TableColumnAttribute, string>(
                    "ServiceTableColumn", (property, attributes) => attributes.Single().ColumnType.ToString()));
        }

        public System.Data.Entity.DbSet<XamarinAzureDayService.DataObjects.BusinessTripExpense> BusinessTripExpenses { get; set; }

        public System.Data.Entity.DbSet<XamarinAzureDayService.DataObjects.LeaveRecord> LeaveRecords { get; set; }

        public System.Data.Entity.DbSet<XamarinAzureDayService.DataObjects.WorkLog> WorkLogs { get; set; }
    }

}

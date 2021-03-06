﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Authentication;
using Microsoft.Azure.Mobile.Server.Config;
using XamarinAzureDayService.DataObjects;
using XamarinAzureDayService.Models;
using Owin;

using System.Data.Entity.Migrations;
using XamarinAzureDayService.Migrations;

namespace XamarinAzureDayService
{
    public partial class Startup
    {
        public static void ConfigureMobileApp(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            //For more information on Web API tracing, see http://go.microsoft.com/fwlink/?LinkId=620686 
            config.EnableSystemDiagnosticsTracing();

            new MobileAppConfiguration()
                .UseDefaultConfiguration()
                .ApplyTo(config);

            #region 啟用 Code First Migration 功能
            // Use Entity Framework Code First to create database tables based on your DbContext
            //Database.SetInitializer(new XamarinAzureDayInitializer());

            // 因為 Azure Mobile 關閉了 Code First Auto Migration，我們需要啟用 Code First Migration 功能
            var migrator = new DbMigrator(new Migrations.Configuration());
            migrator.Update();
            #endregion

            // To prevent Entity Framework from modifying your database schema, use a null database initializer
            // Database.SetInitializer<XamarinAzureDayContext>(null);

            MobileAppSettingsDictionary settings = config.GetMobileAppSettingsProvider().GetMobileAppSettings();

            if (string.IsNullOrEmpty(settings.HostName))
            {
                // This middleware is intended to be used locally for debugging. By default, HostName will
                // only have a value when running in an App Service application.
                app.UseAppServiceAuthentication(new AppServiceAuthenticationOptions
                {
                    SigningKey = ConfigurationManager.AppSettings["SigningKey"],
                    ValidAudiences = new[] { ConfigurationManager.AppSettings["ValidAudience"] },
                    ValidIssuers = new[] { ConfigurationManager.AppSettings["ValidIssuer"] },
                    TokenHandler = config.GetAppServiceTokenHandler()
                });
            }
            app.UseWebApi(config);
        }
    }

    public class XamarinAzureDayInitializer : CreateDatabaseIfNotExists<XamarinAzureDayContext>
    {
        protected override void Seed(XamarinAzureDayContext context)
        {
            List<TodoItem> todoItems = new List<TodoItem>
            {
                new TodoItem { Id = Guid.NewGuid().ToString(), Text = "First item", Complete = false },
                new TodoItem { Id = Guid.NewGuid().ToString(), Text = "Second item", Complete = false },
            };

            foreach (TodoItem todoItem in todoItems)
            {
                context.Set<TodoItem>().Add(todoItem);
            }

            base.Seed(context);
        }
    }
}


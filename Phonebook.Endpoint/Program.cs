using ApplicationPhoneBook.DataBase;
using ApplicationPhoneBook.Services.AddNewContact;
using ApplicationPhoneBook.Services.DeleteContact;
using ApplicationPhoneBook.Services.GetlistContact;
using ApplicationPhoneBook.Services.ShowDetail;
using Microsoft.Extensions.DependencyInjection;
using PersistencePhoneBook.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI_winForm.Forms;

namespace Phonebook.Endpoint
{
    static class Program
    {

        public static IServiceProvider ServiceProvider { get; set; }


        static void ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddScoped<IDataBaseContext, DatabaseContext>();
            services.AddScoped<IAddNewContactService, AddNewContactService>();
            services.AddScoped<IGetlistContactService, GetlistContactService>();
            services.AddScoped<iShowDetailService, ShowDetailService>();
            services.AddTransient<IDeleteContactService, DeleteContactService>();
            services.AddDbContext<DatabaseContext>();

            ServiceProvider = services.BuildServiceProvider();
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ConfigureServices();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var serviceGetList = (IGetlistContactService)ServiceProvider.GetService(typeof(IGetlistContactService));
            var serviceDelete = (IDeleteContactService)ServiceProvider.GetService(typeof(IDeleteContactService));
            
            
            Application.Run(new frmMain(serviceGetList,serviceDelete));
        }
    }
}

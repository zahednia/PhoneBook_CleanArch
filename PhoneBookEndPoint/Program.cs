using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI_winForm.Forms;
using Microsoft.Extensions.DependencyInjection;
using ApplicationPhoneBook.DataBase;
using Persistance.Context;
using ApplicationPhoneBook.Services.AddNewContact;

namespace PhoneBookEndPoint
{
    static class Program
    {
        public static IServiceProvider ServiceProvider { get; set; }

        static void ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddScoped<IDataBaseContext, DataBaseContext>();
            services.AddScoped<IAddNewService, AddNewService>();
            services.AddDbContext<DataBaseContext>();
            ServiceProvider = services.BuildServiceProvider();
        }
        [STAThread]
        static void Main() {
            ConfigureServices();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.Run(new frmMain());
        }
    }
}

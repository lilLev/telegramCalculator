using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using TelegramCalculator.UI.Configurations;

namespace TelegramCalculator.UI
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var serviceProvider = DiConfig.ConfigureServices(new ServiceCollection())
                .BuildServiceProvider();
            var form = serviceProvider.GetRequiredService<Form1>();
            
            Application.Run(form);
        }
    }
}

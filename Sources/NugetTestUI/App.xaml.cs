using System.Windows;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Models;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Services;

namespace Mmu.Mlh.ScreenScraping.NugetTestUI
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var containerConfig = ContainerConfiguration.CreateFromAssembly(typeof(App).Assembly);
            using (var container = ContainerInitializationService.CreateInitializedContainer(containerConfig))
            {
                var window = container.GetInstance<MainWindow>();
                window.ShowDialog();
            }
        }
    }
}
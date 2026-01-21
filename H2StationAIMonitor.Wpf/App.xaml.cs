using H2StationAIMonitor.Core._Tests;
using H2StationAIMonitor.Wpf._Tests;
using System.Configuration;
using System.Data;
using System.Windows;

namespace H2StationAIMonitor.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly CancellationTokenSource _cts = new();

        // test
        protected override void OnStartup(StartupEventArgs e)
        {
            //base.OnStartup(e);

            var runtime = new CoreToWpfConnectionTest();
            runtime.Start(_cts.Token);
            var vm = new CoreToWpfConnectionTestWindowViewModel(runtime, _cts.Token);
            var win = new CoreToWpfConnectionTestWindow { DataContext = vm };
            win.Closed += (_, __) => vm.Dispose();
            win.Show();
        }
    }

}

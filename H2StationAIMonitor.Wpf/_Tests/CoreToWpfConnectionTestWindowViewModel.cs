using CommunityToolkit.Mvvm.ComponentModel;
using H2StationAIMonitor.Core._Tests;

namespace H2StationAIMonitor.Wpf._Tests
{
    partial class CoreToWpfConnectionTestWindowViewModel : ObservableObject, IDisposable
    {

        private readonly CancellationTokenSource _cts = new();
        private readonly CoreToWpfConnectionTest _core;

        [ObservableProperty]
        private int count;

        public CoreToWpfConnectionTestWindowViewModel(CoreToWpfConnectionTest runtime, CancellationToken ct)
        {
            _core = new CoreToWpfConnectionTest();

            _core.CountChanged += n =>
            {
                App.Current.Dispatcher.Invoke(() => Count = n);
            };

            _core.Start(_cts.Token);
        }

        public void Dispose() => _cts.Cancel();
    }
}

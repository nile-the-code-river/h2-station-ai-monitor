namespace H2StationAIMonitor.Core._Tests
{
    public sealed class CoreToWpfConnectionTest
    {

        public event Action<int>? CountChanged;
        private int _count;

        public void Start(CancellationToken ct)
        {
            _ = Task.Run(async () =>
            {
                while (!ct.IsCancellationRequested)
                {
                    await Task.Delay(1000, ct);
                    _count++;
                    CountChanged?.Invoke(_count);
                }
            }, ct);
        }
    }
}

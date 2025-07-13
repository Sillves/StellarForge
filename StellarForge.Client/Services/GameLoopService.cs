using StellarForge.Shared.Services.Interfaces;

namespace StellarForge.Client.Services;

public class GameLoopService : IAsyncDisposable
{
    private readonly IGameStateService _state;
    private readonly PeriodicTimer _timer;
    private readonly CancellationTokenSource _cts = new();

    public event Action? OnTick;
    public GameLoopService(IGameStateService state)
    {
        _state = state;
        _timer = new PeriodicTimer(TimeSpan.FromSeconds(1));
        _ = RunAsync();
    }

    private async Task RunAsync()
    {
        while (await _timer.WaitForNextTickAsync(_cts.Token))
        {
            _state.Add(Shared.Models.ResourceType.Titanium, 1);
            OnTick?.Invoke();
        }
    }

    public System.Threading.Tasks.ValueTask DisposeAsync()
    {
        _cts.Cancel();
        _timer.Dispose();
        return ValueTask.CompletedTask;
    }
}

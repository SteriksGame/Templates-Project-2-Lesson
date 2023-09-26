using System;

public class RestartMenu : WindowBase
{
    public event Action Restart;

    public void OnRestartButton() => Restart?.Invoke();
}

using System;

public class RestartMenu : UIMenu
{
    public event Action Restart;

    public void OnRestartButton() => Restart?.Invoke();
}

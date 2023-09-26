using System;
using UnityEngine;

public class Mediator : MonoBehaviour, IDisposable
{
    [SerializeField] private IndicationMenuView _indicationMenuView;
    [SerializeField] private RestartMenu _restartMenu;

    private PlayerStats _playerStats;
    private Level _level;

    public void Initialized(PlayerStats playerStats, Level level)
    {
        _restartMenu.Restart += OnRestartGame;

        _playerStats = playerStats;
        _playerStats.Level.OnChanged += OnChangePlayerLevel;
        _playerStats.Heal.OnChanged += OnChangePlayerHeal;

        _level = level;
        _level.Lose += OnLoseGame;

        _playerStats.ResetPlayer();
    }

    public void Dispose()
    {
        _restartMenu.Restart -= OnRestartGame;

        _playerStats.Level.OnChanged -= OnChangePlayerLevel;
        _playerStats.Heal.OnChanged -= OnChangePlayerHeal;

        _level.Lose -= OnLoseGame;
    }

    private void OnChangePlayerLevel(int value) => _indicationMenuView.ChangeViewLevel(value);

    private void OnChangePlayerHeal(int value)
    {
        _indicationMenuView.ChangeViewHeal(value);
        _level.CheckLose(value);
    }

    private void OnLoseGame()
    {
        _playerStats.Input.Disable();
        _restartMenu.Open();
    }

    private void OnRestartGame()
    {
        _playerStats.ResetPlayer();
        _playerStats.Input.Enable();

        _restartMenu.Close();
    }
}

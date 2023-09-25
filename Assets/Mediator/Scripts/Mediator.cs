using System;
using UnityEngine;

public class Mediator : MonoBehaviour, IDisposable
{
    [SerializeField] private IndicationMenuView _indicationMenuView;
    [SerializeField] private RestartMenu _restartMenu;

    private PlayerCharacteristic _playerCharacteristic;

    public void Initialized(PlayerCharacteristic playerCharacteristic)
    {
        _restartMenu.Restart += OnRestartGame;

        _playerCharacteristic = playerCharacteristic;

        _playerCharacteristic.ChangedLevel += OnChangePlayerLevel;
        _playerCharacteristic.ChangedHeal += OnChangePlayerHeal;

        _playerCharacteristic.ResetPlayer();
    }

    public void Dispose()
    {
        _restartMenu.Restart -= OnRestartGame;

        _playerCharacteristic.ChangedLevel -= OnChangePlayerLevel;
        _playerCharacteristic.ChangedHeal -= OnChangePlayerHeal;
    }

    private void OnChangePlayerLevel(int value) => _indicationMenuView.ChangeViewLevel(value);

    private void OnChangePlayerHeal(int value)
    {
        if(value == 0)
        {
            _playerCharacteristic.Input.Disable();
            _restartMenu.Open();
        }

        _indicationMenuView.ChangeViewHeal(value);
    }

    private void OnRestartGame()
    {
        _playerCharacteristic.ResetPlayer();
        _playerCharacteristic.Input.Enable();

        _restartMenu.Close();
    }
}

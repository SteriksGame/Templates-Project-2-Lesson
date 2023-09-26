using System;

public class PlayerStats : IDisposable
{
    private const int START_LEVEL_VALUE = 0;
    private const int START_HEAL_VALUE = 10;

    private const int MAX_LEVEL_VALUE = 20;
    private const int MAX_HEAL_VALUE = 10;

    private IntValue _level;
    private IntValue _heal;
    
    private PlayerInput _input;

    public PlayerStats(PlayerInput input)
    {
        _input = input;

        _level = new IntValue(START_LEVEL_VALUE, MAX_LEVEL_VALUE);
        _heal = new IntValue(START_HEAL_VALUE, MAX_HEAL_VALUE);

        _input.Characteristic.LevelAdd.started += AddLevel;
        _input.Characteristic.LevelReduce.started += ReduceLevel;

        _input.Characteristic.HealAdd.started += AddHeal;
        _input.Characteristic.HealReduce.started += ReduceHeal;

        _input.Characteristic.Enable();
    }

    public PlayerInput Input => _input;

    public IntValue Level => _level;
    public IntValue Heal => _heal;

    public void Dispose()
    {
        _input.Characteristic.LevelAdd.started -= AddLevel;
        _input.Characteristic.LevelReduce.started -= ReduceLevel;

        _input.Characteristic.HealAdd.started -= AddHeal;
        _input.Characteristic.HealReduce.started -= ReduceHeal;

        _input.Characteristic.Disable();
    }

    public void ResetPlayer()
    {
        _level.Reset();
        _heal.Reset();
    }

    public void AddLevel(UnityEngine.InputSystem.InputAction.CallbackContext context) => _level.Add();
    public void ReduceLevel(UnityEngine.InputSystem.InputAction.CallbackContext context) => _level.Reduce();

    public void AddHeal(UnityEngine.InputSystem.InputAction.CallbackContext context) => _heal.Add();
    public void ReduceHeal(UnityEngine.InputSystem.InputAction.CallbackContext context) => _heal.Reduce();
}

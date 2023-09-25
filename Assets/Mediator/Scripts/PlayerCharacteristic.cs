using System;

public class PlayerCharacteristic : IDisposable
{
    public event Action<int> ChangedLevel;
    public event Action<int> ChangedHeal;

    private int _level;
    private int _heal;
    
    private PlayerInput _input;

    private const int MAX_LEVEL_VALUE = 20;
    private const int MAX_HEAL_VALUE = 10;

    public PlayerCharacteristic(PlayerInput input)
    {
        _input = input;

        _input.Characteristic.LevelAdd.started += AddLevel;
        _input.Characteristic.LevelReduce.started += ReduceLevel;

        _input.Characteristic.HealAdd.started += AddHeal;
        _input.Characteristic.HealReduce.started += ReduceHeal;

        _input.Characteristic.Enable();
    }

    public void Dispose()
    {
        _input.Characteristic.LevelAdd.started -= AddLevel;
        _input.Characteristic.LevelReduce.started -= ReduceLevel;

        _input.Characteristic.HealAdd.started -= AddHeal;
        _input.Characteristic.HealReduce.started -= ReduceHeal;

        _input.Characteristic.Disable();
    }

    public PlayerInput Input => _input;

    public void ResetPlayer()
    {
        _level = 0;
        _heal = MAX_HEAL_VALUE;

        ChangedLevel?.Invoke(_level);
        ChangedHeal?.Invoke(_heal);
    }

    public void AddLevel(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (_level == MAX_LEVEL_VALUE)
            return;

        _level++;
        ChangedLevel?.Invoke(_level);
    }
    public void ReduceLevel(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (_level == 0)
            return;

        _level--;
        ChangedLevel?.Invoke(_level);
    }

    public void AddHeal(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (_heal == MAX_HEAL_VALUE)
            return;

        _heal++;
        ChangedHeal?.Invoke(_heal);
    }
    public void ReduceHeal(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if(_heal <= 0) 
            return;

        _heal--;
        ChangedHeal?.Invoke(_heal);
    }
}

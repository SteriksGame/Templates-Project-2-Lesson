using System;

public abstract class ChangedValue<T> where T : IConvertible
{
    public event Action<T> OnChanged;

    protected T _value;
    protected T _maxValue;

    private T _startValue;

    public ChangedValue(T value, T maxValue)
    {
        _value = value;
        _maxValue = maxValue;

        _startValue = value;
    }

    public T Value => _value;

    public void Reset()
    {
        _value = _startValue;
        Changed();
    }

    public abstract void Add();
    public abstract void Reduce();

    protected void Changed() => OnChanged?.Invoke(_value);
}
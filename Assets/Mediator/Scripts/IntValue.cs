public class IntValue : ChangedValue<int>
{
    public IntValue(int value, int maxValue) : base(value, maxValue) { }

    public override void Add()
    {
        if (_value == _maxValue)
            return;

        _value++;
        Changed();
    }
    public override void Reduce()
    {
        if (_value == 0)
            return;

        _value--;
        Changed();
    }
}


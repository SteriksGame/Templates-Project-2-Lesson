using System;

public class Level
{
    public event Action Lose;

    public void CheckLose(int value)
    {
        if (value == 0) 
            Lose?.Invoke();
    }
}

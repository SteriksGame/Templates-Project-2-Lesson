using System.Collections.Generic;
using System.Linq;

public class CharacterStateMachine : IStateSwitcher
{
    private List<IState> _states;
    private IState _currentState;

    public CharacterStateMachine(Character character)
    {
        StateMachineData data = new StateMachineData();
        data.TargetTransform = character.TransformHome;

        _states = new List<IState>()
        {
            new MoveState(this, data, character),
            new RestState(this, data, character),
            new WorkerState(this, data, character),
        };

        _currentState = _states[0];
        _currentState.Enter();
    }

    public void SwitchState<T>() where T : IState
    {
        IState state = _states.FirstOrDefault(state => state is T);

        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    public void HandleInput() => _currentState.HandleInput();

    public void Update() => _currentState.Update();
}
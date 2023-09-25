using UnityEngine;

public abstract class MovementState : IState
{
    protected readonly IStateSwitcher StateSwitcher;
    protected readonly StateMachineData Data;

    protected readonly Character _character;

    public MovementState(IStateSwitcher stateSwitcher, StateMachineData data, Character character)
    {
        StateSwitcher = stateSwitcher;
        Data = data;

        _character = character;
    }

    protected PlayerInput Input => _character.Input;
    protected CharacterController Controller => _character.Controller;

    private Quaternion _turnForward => new Quaternion(0, 0, 0, 0);
    private Quaternion _turnBack => Quaternion.Euler(0, 180, 0);

    public virtual void Enter()
    {
        Debug.Log(GetType());

        AddInputActionsCallback();
    }

    public virtual void Exit()
    {
        RemoveInputActionsCallback();
    }

    public void HandleInput()
    {
        
    }

    public virtual void Update()
    {
        Vector3 velocity = GetConvertedVelocity();

        Controller.Move(velocity * Data.Speed * Time.deltaTime);
        _character.transform.rotation = GetRotationFrom(velocity);
    }

    protected bool IsOnTarget()
    {
        if (Vector3.Distance(_character.transform.position, Data.TargetTransform.transform.position) < 0.1f)
            return true;

        return false;
    }

    protected virtual void AddInputActionsCallback() { }

    protected virtual void RemoveInputActionsCallback() { }

    private Vector3 GetConvertedVelocity()
    {
        Vector3 velocity = Data.TargetTransform.transform.position - _character.transform.position;
        velocity.Normalize();

        return velocity;
    }

    private Quaternion GetRotationFrom(Vector3 velocity)
    {
        if (velocity.z > 0)
            return _turnForward;

        if (velocity.z < 0)
            return _turnBack;

        return _character.transform.rotation;
    }
}

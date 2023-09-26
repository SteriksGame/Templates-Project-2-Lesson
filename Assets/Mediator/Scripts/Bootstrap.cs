using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Mediator _mediator;

    private void Awake()
    {
        PlayerInput input = new PlayerInput();

        PlayerStats playerStats = new PlayerStats(input);
        Level level = new Level();

        _mediator.Initialized(playerStats, level);
    }
}

using UnityEngine;

[CreateAssetMenu(fileName = "CharacterConfig", menuName = "Config/CharacterConfig")]
public class CharacterConfig : ScriptableObject
{
    [SerializeField] private MoveStateConfig _moveStateConfig;
    [SerializeField] private RestStateConfig _restStateConfig;
    [SerializeField] private WorkerStateConfig _workerStateConfig;

    public MoveStateConfig MoveStateConfig => _moveStateConfig;
    public RestStateConfig RestStateConfig => _restStateConfig;
    public WorkerStateConfig WorkerStateConfig => _workerStateConfig;
}

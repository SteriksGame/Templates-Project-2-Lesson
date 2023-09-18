using UnityEngine;

public class TargetTransformCharacter : MonoBehaviour
{
    public enum TypeTargets
    { 
        Home,
        Work
    }

    [SerializeField] private TypeTargets _typeTarget;

    public TypeTargets TypeTarget => _typeTarget;
}
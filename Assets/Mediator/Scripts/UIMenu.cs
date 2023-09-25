using UnityEngine;

public class UIMenu : MonoBehaviour
{
    public void Open() => gameObject.SetActive(true);
    public void Close() => gameObject.SetActive(false);
}

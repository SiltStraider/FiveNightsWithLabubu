using UnityEngine;

public class InteractObject : MonoBehaviour
{
    public bool IsActive { get; protected set; }
    
    public bool ChekInteract()
    {
        return !CameraSwitcher.Instance.IsActivePanel;
    }
}

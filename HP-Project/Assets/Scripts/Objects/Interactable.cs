using UnityEngine;

public class Interactable : MonoBehaviour
{
    
    public virtual void InteractedWith()
    {
        Debug.Log("You interacted with: " + name);
    }

}

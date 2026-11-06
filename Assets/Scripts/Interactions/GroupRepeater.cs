using UnityEngine;

public class GroupRepeater : MonoBehaviour, IActivable
{
    public void Activate(bool activate)
    {
        foreach (IActivable child in GetComponentsInChildren<IActivable>())
        {
            if ((Object)child == this) continue; 
            child.Activate(activate);
        }
    }
}
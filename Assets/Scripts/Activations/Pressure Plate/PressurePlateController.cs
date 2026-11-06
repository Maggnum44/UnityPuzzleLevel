using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class PressurePlateController : ActivatorBase
{   
    
    //Public bool staypressed

    public bool stayPressed = false;

    private int _objectsOnPlate = 0;


   

    
    //Cuando entra se activa y comprobamos si tiene el pressure plate activator, ahora mismo solo lo tiene el personaje
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PressurePlateActivator activator))
        {
            if (_objectsOnPlate == 0)
            {
                _isActivated = true;
                ActivateObjects(_isActivated);
            }
            _objectsOnPlate++;
        }
    }

    // Caundo sale se activa
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PressurePlateActivator activator))
        {
            _objectsOnPlate--;
            if (_objectsOnPlate == 0 && !stayPressed)
            {
                Release();
                
            }
        }
    }


    //Public void release
     public void Release()
    {
        if (!_isActivated) return;
        ActivateObjects(false);
    }
}

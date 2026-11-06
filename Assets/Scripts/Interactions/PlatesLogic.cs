using UnityEngine;
using System.Collections.Generic;

public class PlatesLogic : ActivatorBase
{
   
    public ActivatorBase[] plates;
    public List<GameObject> TrapsToActivate = new List<GameObject>();

    int correctPlateIndex = 0;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var activatorState in plates){
            activatorState.ToActivate.AddListener(PlatePulsed);
        }
    }

    private void PlatePulsed(ActivatorBase.ActivatorInfo info){

        if (_isActivated) return;

        if (info.Activator.IsActivated){

            int plateIndex = System.Array.IndexOf(plates, info.Activator);
            Debug.Log("M'epero la plate index "+correctPlateIndex+" ha fet press a index "+plateIndex);
            
            //check de si es el correcte.
            if (correctPlateIndex == plateIndex){
                Debug.Log("OK!");
                //si ->  augmento index i espero la seguent
                correctPlateIndex++;
                if(plateIndex == plates.Length-1)
                {
                    //check de si index == max plaques -> puzle completat. Puzzle completat i obro porta
                    Debug.Log("Puzzle completat");
                    _isActivated = true;
                    ActivateObjects(true);
                }
            }
            else
            {
                Debug.Log("Index reset");
                //no -> activo trampa i reset del index.
                correctPlateIndex = 0;
                //Si el puzzle no es correcte, fes el release de totes les plaques 
                foreach (var plate in plates){
                    PressurePlateController pressurePlate = plate.GetComponent<PressurePlateController>();
                    if (pressurePlate != null)
                    pressurePlate.Release();
                }
                
                
             foreach (var trap in TrapsToActivate){
                IActivable activable = trap.GetComponent<IActivable>();
                if (activable != null)
                activable.Activate(true);
        }
                
                _isActivated = false;
            }
        
        
            //(si) check de si index == max plaques -> puzle completat.
            
        }
    }
}

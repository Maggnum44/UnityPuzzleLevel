using UnityEngine;
using System.Collections.Generic;
public class BasicPuzzle : ActivatorBase
{
    [System.Serializable]
    public class ActivatorPuzzleState
    {
        public ActivatorBase activator;
        public bool correctState = false;
    }
    public List<ActivatorPuzzleState> activators;

    void Start()
    {
        foreach (var activatorState in activators)
        {
            activatorState.activator.ToActivate.AddListener(ActivatorUpdated);
        }
    }

    private void ActivatorUpdated(ActivatorBase.ActivatorInfo info)
    {
        if (CheckIfPuzzleHasBeenSolved())
        {
            Debug.Log("Puzzle Solved!");
            ActivateObjects(true);
        }
        else
        {
            Debug.Log("Puzzle not yet solved!");
            ActivateObjects(false);
        }

    }

    private bool CheckIfPuzzleHasBeenSolved()
    {
        foreach (var activatorState in activators)
        {
            if (activatorState.activator.IsActivated != activatorState.correctState)
            {
                return false;
            }
        }
        return true;
    }

}
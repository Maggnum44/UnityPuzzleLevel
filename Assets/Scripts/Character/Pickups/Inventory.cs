using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
   [SerializeField] int coins;

   [SerializeField] TMP_Text coinCounter;

    public UnityAction OnInventoryUpdated;
    public int GetCoins()
    {
        
        return coins;
    }
   public void AddOrSubtractPoints(int amount)
    {
        
        
        coins += amount;
        OnInventoryUpdated?.Invoke();


    }
}

using System;
using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private TMP_Text coinCounter;

    [SerializeField] private Inventory inventory;

    private Animator coinAnimation;

    void Awake()
    {
        
        coinAnimation = GetComponent<Animator>();

    }
    void Start()
    {
        inventory.OnInventoryUpdated = UpdateCounter;
        UpdateCounter();
        
    }

    void UpdateCounter()
    {
        coinCounter.text = inventory.GetCoins().ToString();
        coinAnimation.SetTrigger("Pickup");

    }
   
}

using System;
using Gameplay.Systems;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HPBarController : MonoBehaviour
{
    [SerializeField] private TMP_Text healthIndicator;

    [SerializeField] private Image imageHPBar;

    [SerializeField] private Damageable beenDamaged;


    void Start()
    {
        beenDamaged.OnDamageTaken += HealthUpdate;
        healthIndicator.text = beenDamaged.MaxHitpoints.ToString();
        
    }
    private void HealthUpdate(float damage)
    {
        
        
        healthIndicator.text = $"{beenDamaged.CurrentHitpoints}/{beenDamaged.MaxHitpoints}";
        imageHPBar.fillAmount = beenDamaged.CurrentHitpoints / beenDamaged.MaxHitpoints;

    }

    


}

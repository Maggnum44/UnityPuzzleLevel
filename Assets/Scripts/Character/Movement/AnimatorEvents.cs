using UnityEngine;
using System.Collections.Generic;

public class CharacterAttackAnimator : MonoBehaviour
{

    private CharacterHabilities _characterHabilities;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public void Awake()
    {

    _characterHabilities = GetComponentInParent<CharacterHabilities>();

    
    }

    public void doDamageAnimator()
    {
        Debug.Log("doDamageAnimator");
        _characterHabilities.HurtDamageables();

    }

    


    
}

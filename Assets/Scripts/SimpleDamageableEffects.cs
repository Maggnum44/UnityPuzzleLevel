using Gameplay.Systems;
using UnityEngine;

public class SimpleDamageableEffects : MonoBehaviour
{

    private Animator _animator;

    private Damageable _damageable;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _damageable = GetComponent<Damageable>();
        _animator = GetComponent<Animator>();

        _damageable.OnDeath += OnDeath;
        _damageable.OnDamageTaken += PlayHurtAnimation;
    }

    //Cuando el damageable rep dany, es crida aquesta funció per activar l'animació de rebre dany
    public void PlayHurtAnimation(float damage)
    {
        
        _animator.SetTrigger("Hurt");
        
        
    }

    private void OnDeath()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
    
}
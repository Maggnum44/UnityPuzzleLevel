using Gameplay.Systems;
using UnityEngine;

public class SpikeController : MonoBehaviour, IActivable //He afegit IActivable per poder activar les trampas desde el puzzle.
{

    public float DamageAmount = 50f; //Mal per cop

    private Animator _animator;
    private bool _canDamage = false; //Booleano per saber si pot fer mal, s'activa quan l'animació de activació està activa.

    void Awake()
    {
        //Getter del animator.
        _animator = GetComponent<Animator>();
    }

    public void Activate(bool activate)
    {
        if (activate)
        {
            //Trigger per activar l'animació de les punxes.
            _animator.SetTrigger("WrongPuzzle");
        }
        
    }

    public void SpikesUp()
    {
        _canDamage = true;
    }

        public void SpikesDown()
    {
        _canDamage = false;
    }
    
 
    void OnTriggerStay(Collider other)
        {
            //Si no estan actius no poden fer mal.
            if (!_canDamage) return;


            //Només faig mal a lo que sigui damageable
            Damageable damageable = other.GetComponent<Damageable>();
            if(damageable != null)
            {
                damageable.TakeDamage(DamageAmount);
                _canDamage = false; //Un cop mal per activació
            }
        }
}

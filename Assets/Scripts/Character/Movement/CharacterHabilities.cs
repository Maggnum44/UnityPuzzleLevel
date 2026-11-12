using Gameplay.Systems;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;


public class CharacterHabilities : MonoBehaviour
{
   
   public UnityAction OnAttack;

   [SerializeField] private Collider _basicAttackCollider;

   public float damage = 30f;
    private bool habilitiesEnabled = true;

public void SetHabilitiesEnabled(bool enabled)
        {
            habilitiesEnabled = enabled;
        }
    public void Attack()
    {
        //Si está muerto que no pueda atacar
        if (!habilitiesEnabled)
            {
               return;
            }
        
        OnAttack?.Invoke();
        //Debug.Log("[CharacterHabilities] Attack triggered");
    }
    
    //Això ho fa el animator
    public void HurtDamageables()
    {

        //miro quins damageables estan dins del trigger i els faig mal els que toqui
        var damageablesFound = Physics.OverlapBox(_basicAttackCollider.bounds.center, _basicAttackCollider.bounds.extents, _basicAttackCollider.transform.rotation);


        foreach (var damageable in damageablesFound)
        {
            if(damageable.TryGetComponent<Damageable>(out var damageableComponent))
            {
                Debug.Log("Applying damage to: " + damageable.name);
                damageableComponent.TakeDamage(damage);
            }
        }
    }
}

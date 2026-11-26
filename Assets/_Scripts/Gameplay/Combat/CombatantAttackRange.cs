using UnityEngine;

public class CombatantAttackRange : MonoBehaviour
{
    [SerializeField] private Combatant combatant;

    private void Awake()
    {
        combatant = GetComponentInParent<Combatant>();

        if (combatant == null)
        {
            Debug.LogError("Combatant component not found in parent of " + gameObject.name);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Combatant otherCombatant = collision.GetComponentInParent<Combatant>();
        if (otherCombatant != null && otherCombatant != combatant)
        {
            combatant.UpdateEnemy(otherCombatant);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Combatant otherCombatant = collision.GetComponentInParent<Combatant>();
        if (otherCombatant != null && otherCombatant == combatant.enemy)
        {
            combatant.UpdateEnemy(null);
        }
    }
}

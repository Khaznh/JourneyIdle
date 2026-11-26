using UnityEngine;

public class AnimationEventReceiver : MonoBehaviour
{
    [SerializeField] private Combatant combatant;

    private void OnEnable()
    {
        GetData();
    }

    private void Reset()
    {
        GetData();
    }

    private void GetData()
    {
        combatant = GetComponentInParent<Combatant>();
    }

    public void OnAttack()
    {
        CombatController.Instance.CalcDamage(combatant, combatant.enemy, combatant.combatantAnimator);
    }
}

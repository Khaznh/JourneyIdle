using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CombatController : Singleton<CombatController>
{
    public void Attack(Combatant attacker)
    {
        float attackSpeed = attacker.baseStats.attackSpeed;
        if (attackSpeed <= 0f) return;

        Animator anim = attacker.combatantAnimator;

        float clipLength = GetClipLength(anim, "Attack");
        float speedMultiplier = clipLength * attackSpeed;
        anim.SetFloat("AniSpeed", speedMultiplier);
        anim.Play("Attack", 0, 0f);
    }

    public void CalcDamage(Combatant attacker, Combatant defender, Animator anim)
    {
        float evade = Random.Range(0, 1f);
        if (evade < defender.baseStats.evadeRate)
        {
            Debug.Log(defender.name + " evaded the attack!");
            return;
        }

        float attackValue = attacker.baseStats.attack;

        float crit = Random.Range(0, 1f);
        if (crit < attacker.baseStats.critRate)
        {
            attackValue = attackValue * attacker.baseStats.critMultiplier;
        }

        float attackPercenAfterDefValue = (attackValue * 100) / (100 + defender.baseStats.defense);

        defender.TakeDamage((int)attackPercenAfterDefValue);
    }

    private float GetClipLength(Animator anim, string clipName)
    {
        if (anim.runtimeAnimatorController == null) return 1f;

        foreach (AnimationClip clip in anim.runtimeAnimatorController.animationClips)
        {
            if (clip.name == clipName)
            {
                return clip.length;
            }
        }

        return 1f;
    }
}

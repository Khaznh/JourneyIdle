using System;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{
    public event Action<Combatant, int, int> OnHealthChange;

    public void OnHealthCombatantChange(Combatant combatant, int currentHealth, int maxHealth)
    {
        OnHealthChange?.Invoke(combatant, currentHealth, maxHealth);
    }
}

using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Combatant : MonoBehaviour
{
    [Header("Combatant Stats")]
    public BaseStats baseStats;

    [Header("Combatant Current Stats")]
    [SerializeField] private int maxHealth;
    public int currentHealth;

    [Header("Combatant Type")]
    public CombatantType combatantType;
    public Combatant enemy;

    [Header("Combatant Misc")]
    public Animator combatantAnimator;

    private float timer = 0f;

    public void Awake()
    {
        baseStats = GetComponent<BaseStats>();
        combatantAnimator = GetComponentInChildren<Animator>();
        if (baseStats == null)
        {
            Debug.LogError("BaseStats component not found on " + gameObject.name);
            return;
        }

        maxHealth = baseStats.health;
        currentHealth = maxHealth;
    }

    public void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
            return;
        }

        if (enemy == null || !enemy.gameObject.activeInHierarchy)
        {
            enemy = null;
            return;
        }

        Attack();
    }

    public void Attack()
    {
        float interval = 1f / baseStats.attackSpeed;
        timer += Time.deltaTime;

        while (timer >= interval)
        {
            timer = 0;
            CombatController.Instance.Attack(this, enemy, baseStats);
        }
    }

    public void UpdateEnemy(Combatant combatant)
    {
        if (combatant == null)
        {
            enemy = null;
            return;
        }

        if (combatant.combatantType == combatantType)
        {
            return;
        }

        enemy = combatant;
    }

    public void Die()
    {
        gameObject.SetActive(false);
        Debug.Log(gameObject.name + " has died.");
    }
}

public enum CombatantType
{
    Player,
    Enemy
}
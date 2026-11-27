using System;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.Rendering.Universal;

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
        GetData();
    }

    public void Reset()
    {
        GetData();
    }

    public void Start()
    {
        EventManager.Instance.OnHealthCombatantChange(this, currentHealth, maxHealth);
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
            CombatController.Instance.Attack(this);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        EventManager.Instance.OnHealthCombatantChange(this, currentHealth, maxHealth);
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

    public void GetData()
    {
        baseStats = GetComponent<BaseStats>();
        combatantAnimator = GetComponentInChildren<Animator>();

        maxHealth = baseStats.health;
        currentHealth = maxHealth;
    }
}

public enum CombatantType
{
    Player,
    Enemy
}
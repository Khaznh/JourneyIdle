using UnityEngine;

public class BaseStats : MonoBehaviour
{
    [Header("Basic Stats")]
    public int health;
    public int attack;
    public int defense;

    public float attackSpeed;
    [Range(0,1)] public float evadeRate;

    [Header("Advanced Stats")]
    [Range(0, 1)] public float counterRate;

    [Range(0, 1)] public float critRate;
    [Range(2, 4)] public float critMultiplier;

    [Range(0, 1)] public float lifeSteal;
}

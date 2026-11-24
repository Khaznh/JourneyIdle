using UnityEngine;

public class BaseStats : MonoBehaviour
{
    public int health;
    public int attack;
    public int defense;

    public float attackSpeed;
    [Range(0,1)] public float evadeRate;
}

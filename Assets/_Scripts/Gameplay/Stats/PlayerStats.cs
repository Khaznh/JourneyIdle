using UnityEngine;

public class PlayerStats : BaseStats
{
    [Range(0, 1)] public float counterRate;

    [Range(0, 1)] public float critRate;
    [Range(2, 4)] public float critMultiplier;

    [Range(0, 1)] public float lifeSteal;
}

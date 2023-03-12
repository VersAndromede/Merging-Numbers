using System;
using UnityEngine;

public enum MonsterType
{
    Adding,
    Divider
}

public class Monster : MonoBehaviour
{
    [field: SerializeField] public Power Power { get; private set; }
    [field: SerializeField] public MonsterType Type { get; private set; }

    private void OnValidate()
    {
        if (Type == MonsterType.Divider && Power.Value < 1)
            throw new InvalidOperationException("The monster is 'Dividing', in which case the strength cannot be less than 1.");
    }

    public void Init(MonsterType type, int power)
    {
        Type = type;
        Power.Add(power);
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
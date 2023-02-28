using System;
using System.Collections;
using UnityEngine;
public class Boss : MonoBehaviour
{
    [field: SerializeField] public BossHealth BossHealth { get; private set; }
    [field: SerializeField] public int Damage { get; private set; }
    [field: SerializeField] public float RechargeTime { get; private set; }

    public void Init(int damageTaken)
    {
        if (damageTaken < 0)
            throw new ArgumentOutOfRangeException();

        BossHealth.Init(damageTaken);
    }
}
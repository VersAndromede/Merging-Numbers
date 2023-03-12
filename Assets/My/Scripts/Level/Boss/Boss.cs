using System;
using System.Collections;
using UnityEngine;
public class Boss : MonoBehaviour
{
    [SerializeField] private Material _material;

    [field: SerializeField] public BossHealth BossHealth { get; private set; }
    [field: SerializeField] public float RechargeTime { get; private set; }

    public BossData Data { get; private set; }

    public void Init(BossData bossData)
    {
        Data = bossData;
        _material.color = Data.Color;
    }

    public void InitHealth(int damageTaken)
    {
        if (damageTaken < 0)
            throw new ArgumentOutOfRangeException();

        BossHealth.Init(Data.Health, damageTaken);
    }
}
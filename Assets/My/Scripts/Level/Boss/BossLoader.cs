using System;
using System.Collections.Generic;
using UnityEngine;

public class BossLoader : MonoBehaviour, IStorable
{
    [SerializeField] private List<BossData> _bossDatas;
    [SerializeField] private Boss _currentBoss;

    private int _bossDataIndex;

    public event Action<Boss> Loaded;

    private void OnEnable()
    {
        _currentBoss.BossHealth.Health.Died += OnBossDied;
    }

    private void Awake()
    {
        Load();

        if (_bossDataIndex >= _bossDatas.Count)
            _bossDataIndex = _bossDatas.Count - 1;

        _currentBoss.Init(_bossDatas[_bossDataIndex]);
        Loaded?.Invoke(_currentBoss);
    }

    private void OnDisable()
    {
        _currentBoss.BossHealth.Health.Died -= OnBossDied;
    }

    public void Save()
    {
        SaveData saveData = SaveSystem.Load();
        saveData.BossDataIndex = _bossDataIndex;
        SaveSystem.Save(saveData);
    }

    public void Load()
    {
        _bossDataIndex = SaveSystem.Load().BossDataIndex;
    }

    private void OnBossDied()
    {
        _bossDataIndex++;
    }
}
using System;
using UnityEngine;

public class Wallet : MonoBehaviour, IStorable
{
    public event Action CoinsChanged;

    public int Coins { get; private set; }

    private void Awake()
    {
        Load();
    }

    public void AddCoins(int count)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException();

        Coins += count;
        CoinsChanged?.Invoke();
    }

    public void Save()
    {
        SaveData saveData = SaveSystem.Load();
        saveData.Coins = Coins;
        SaveSystem.Save(saveData);
    }

    public void Load()
    {
        Coins = SaveSystem.Load().Coins;
    }
}
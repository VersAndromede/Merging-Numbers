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

    public void AddCoins(uint count)
    {
        ChangeCoins((int)count);
    }

    public void RemoveCoins(uint count)
    {
        ChangeCoins((int)-count);
    }

    public bool IsSolvent(int price)
    {
        return Coins >= price;
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

    private void ChangeCoins(int count)
    {
        Coins += count;
        CoinsChanged?.Invoke();
    }
}
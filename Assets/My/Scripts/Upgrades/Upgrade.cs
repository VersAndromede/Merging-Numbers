using System;
using UnityEngine;

public abstract class Upgrade : MonoBehaviour, IStorable
{
    [SerializeField] private int _id;

    [field: SerializeField] public int MaxLevel { get; private set; }
    [field: SerializeField] public int Price { get; private set; }
    [field: SerializeField] public int BonusValue { get; private set; }

    public event Action LevelChanged;

    public int Level { get; private set; } = 1;
    public bool CanImprove => Level < MaxLevel;

    public abstract int AffectValue();
    public abstract int AffectPrice();

    private void Start()
    {
        Load();
    }

    private void OnValidate()
    {
        int maxId = SaveSystem.Load().UpgradeDatas.Length - 1;

        if (_id < 0 || _id > maxId)
        {
            _id = Mathf.Clamp(_id, 0, maxId);
            Debug.LogWarning($"The upgrade ID cannot exceed the last index ({maxId})" +
                $" of the array of stored upgrades or be lower than 0.");
        }
    }

    public void Improve()
    {
        BonusValue = AffectValue();
        Price = AffectPrice();
        Level++;
        LevelChanged?.Invoke();

        if (Level > MaxLevel)
            throw new ArgumentOutOfRangeException(); 
    }

    public void Save()
    {
        SaveData saveData = SaveSystem.Load();
        saveData.UpgradeDatas[_id] = new()
        {
            Level = Level,
            Price = Price,
            BonusValue = BonusValue
        };

        SaveSystem.Save(saveData);
    }

    public void Load()
    {
        UpgradeData[] upgradeDatas = SaveSystem.Load().UpgradeDatas;

        if (upgradeDatas[_id] == null)
            return;

        Level = upgradeDatas[_id].Level;
        Price = upgradeDatas[_id].Price;
        BonusValue = upgradeDatas[_id].BonusValue;
        LevelChanged?.Invoke();
    }
}
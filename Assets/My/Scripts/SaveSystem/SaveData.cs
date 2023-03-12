using System;

[Serializable]
public class SaveData
{
    public int Coins;
    public int BossDataIndex;
    public UpgradeData[] UpgradeDatas = new UpgradeData[3];
}

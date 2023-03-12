using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    public void TryBuyUpgrade(Upgrade upgrade)
    {
        if (upgrade.CanImprove && _wallet.IsSolvent((int)upgrade.Price))
        {
            upgrade.Improve();
            upgrade.Save();
            _wallet.RemoveCoins((uint)upgrade.Price);
        }
    }
}
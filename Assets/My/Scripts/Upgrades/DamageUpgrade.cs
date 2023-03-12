using UnityEngine;

public class DamageUpgrade : Upgrade
{
    [SerializeField] private float _multiplierValue;
    [SerializeField] private float _multiplierPrice;

    public override int AffectValue()
    {
        return (int)Mathf.Round(BonusValue * _multiplierValue);
    }

    public override int AffectPrice()
    {
        return (int)Mathf.Round(Price * _multiplierPrice);
    }
}
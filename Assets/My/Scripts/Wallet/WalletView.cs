using TMPro;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private TextMeshProUGUI _text;

    private void Start()
    {
        OnCoinsChanged();
    }

    private void OnEnable()
    {
        _wallet.CoinsChanged += OnCoinsChanged;
    }

    private void OnDisable()
    {
        _wallet.CoinsChanged -= OnCoinsChanged;
    }

    private void OnCoinsChanged()
    {
        _text.text = _wallet.Coins.ToString();
    }
}
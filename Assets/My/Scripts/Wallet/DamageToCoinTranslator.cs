using UnityEngine;

public class DamageToCoinTranslator : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private BossHealth _bossHealth;

    private void OnEnable()
    {
        _bossHealth.DamageReceived += OnDamageReceived;
    }

    private void OnDisable()
    {
        _bossHealth.DamageReceived -= OnDamageReceived;
    }

    private void OnDamageReceived(int damageTaken)
    {
        _wallet.AddCoins((uint)damageTaken);
    }
}

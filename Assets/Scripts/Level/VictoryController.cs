using UnityEngine;

public class VictoryController : MonoBehaviour
{
    [SerializeField] private BossHealth _bossHealth;
    [SerializeField] private Health _playerHealth;

    private void OnEnable()
    {
        _bossHealth.Health.Died += OnBossDied;
        _playerHealth.Died += OnPlayerDied;
    }

    private void OnDisable()
    {
        _bossHealth.Health.Died -= OnBossDied;
        _playerHealth.Died -= OnPlayerDied;
    }

    private void OnBossDied()
    {

    }

    private void OnPlayerDied()
    {
        _bossHealth.MakeInvulnerable();
    }
}

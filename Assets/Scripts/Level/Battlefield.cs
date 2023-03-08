using System.Collections;
using UnityEngine;

public class Battlefield : MonoBehaviour
{
    [SerializeField] private BossLoader _bossLoader;
    [SerializeField] private Player _player;
    [SerializeField] private GameMoves _gameMoves;

    private WaitForSeconds _waitTime;
    private Boss _boss;

    private void OnEnable()
    {
        _gameMoves.Ended += Fight;
        _bossLoader.Loaded += OnBossLoaded;
    }

    private void OnDisable()
    {
        _gameMoves.Ended -= Fight;
        _bossLoader.Loaded -= OnBossLoaded;
    }

    private void Fight()
    {
        StartCoroutine(StartFight());
    }

    private IEnumerator StartFight()
    {
        _boss.InitHealth(_player.Damage);
        StartCoroutine(_boss.BossHealth.MakeVulnerable());
        yield return _waitTime;

        while (_player.Health.Value > 0 && _boss.BossHealth.Health.Value > 0)
        {
            _player.Health.TakeDamage(_boss.Data.Damage);
            yield return _waitTime;
        }
    }

    private void OnBossLoaded(Boss boss)
    {
        _boss = boss;
        _boss.InitHealth(_player.Damage);
        _waitTime = new WaitForSeconds(_boss.RechargeTime);
    }
}

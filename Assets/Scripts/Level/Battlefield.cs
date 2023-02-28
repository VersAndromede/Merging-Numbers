using System.Collections;
using UnityEngine;

public class Battlefield : MonoBehaviour
{
    [SerializeField] private Boss _boss;
    [SerializeField] private Player _player;
    [SerializeField] private GameMoves _gameMoves;

    private WaitForSeconds _waitTime;

    private void OnEnable()
    {
        _gameMoves.Ended += Fight;
    }

    private void Start()
    {
        _waitTime = new WaitForSeconds(_boss.RechargeTime);
    }

    private void OnDisable()
    {
        _gameMoves.Ended -= Fight;
    }

    private void Fight()
    {
        StartCoroutine(StartFight());
    }

    private IEnumerator StartFight()
    {
        _boss.Init(_player.Damage);
        StartCoroutine(_boss.BossHealth.MakeVulnerable());
        yield return _waitTime;

        while (_player.Health.Value > 0 && _boss.BossHealth.Health.Value > 0)
        {
            _player.Health.TakeDamage(_boss.Damage);
            yield return _waitTime;
        }
    }
}

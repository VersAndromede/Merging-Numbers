using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class VictoryController : MonoBehaviour
{
    [SerializeField] private BossHealth _bossHealth;
    [SerializeField] private Health _playerHealth;
    [SerializeField] private float _delayToResult;
    [SerializeField] private UnityEvent _playerWon;
    [SerializeField] private UnityEvent _bossWon;

    private WaitForSeconds _waitTime;

    private void OnEnable()
    {
        _bossHealth.Health.Died += OnBossDied;
        _playerHealth.Died += OnPlayerDied;
    }

    private void Start()
    {
        _waitTime = new WaitForSeconds(_delayToResult);
    }

    private void OnDisable()
    {
        _bossHealth.Health.Died -= OnBossDied;
        _playerHealth.Died -= OnPlayerDied;
    }

    private void OnBossDied()
    {
        StartCoroutine(AssignVictory(true));
    }

    private void OnPlayerDied()
    {
        _bossHealth.MakeInvulnerable();
        StartCoroutine(AssignVictory(true));
    }

    private IEnumerator AssignVictory(bool isPlayerWon)
    {
        yield return _waitTime;

        if (isPlayerWon)
            _playerWon?.Invoke();
        else
            _bossWon?.Invoke();
    }
}

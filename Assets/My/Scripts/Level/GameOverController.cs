using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public enum Winner
{
    Player,
    Boss
}

public class GameOverController : MonoBehaviour
{
    [SerializeField] private BossHealth _bossHealth;
    [SerializeField] private Player _player;
    [SerializeField] private float _delayToResult;
    [SerializeField] private UnityEvent _gameOver;

    private WaitForSeconds _waitTime;

    public event Action<Winner> GameOver;

    private void OnEnable()
    {
        _bossHealth.Health.Died += OnBossDied;
        _player.Health.Died += OnPlayerDied;
        _player.Power.Over += OnPlayerDied;
    }

    private void Start()
    {
        _waitTime = new WaitForSeconds(_delayToResult);
    }

    private void OnDisable()
    {
        _bossHealth.Health.Died -= OnBossDied;
        _player.Health.Died -= OnPlayerDied;
        _player.Power.Over -= OnPlayerDied;
    }

    private void OnBossDied()
    {
        StartCoroutine(AssignVictory(Winner.Player));
    }

    private void OnPlayerDied()
    {
        _bossHealth.MakeInvulnerable();
        StartCoroutine(AssignVictory(Winner.Boss));
    }

    private IEnumerator AssignVictory(Winner winner)
    {
        yield return _waitTime;
        GameOver?.Invoke(winner);
        _gameOver?.Invoke();
    }
}

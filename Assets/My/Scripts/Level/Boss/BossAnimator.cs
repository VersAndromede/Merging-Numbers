using UnityEngine;

public class BossAnimator : MonoBehaviour
{
    [SerializeField] private Boss _boss;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameMoves _gameMoves;

    private readonly int _wakesUpAnimation = Animator.StringToHash("Boss Wakes Up");
    private readonly int _dieAnimation = Animator.StringToHash("Boss Die");

    private void OnEnable()
    {
        _gameMoves.Ended += OnGameMovesEnded;
        _boss.BossHealth.Health.Died += OnBossDied;
    }

    private void OnDisable()
    {
        _gameMoves.Ended -= OnGameMovesEnded;
        _boss.BossHealth.Health.Died -= OnBossDied;
    }

    private void OnGameMovesEnded()
    {
        _animator.Play(_wakesUpAnimation);
    }

    private void OnBossDied()
    {
        _animator.Play(_dieAnimation);
    }
}
using UnityEngine;

public class BossAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GameMoves _gameMoves;

    private readonly int _wakesUpAnimation = Animator.StringToHash("Boss Wakes Up");

    private void OnEnable()
    {
        _gameMoves.Ended += OnGameMovesEnded;
    }

    private void OnDisable()
    {
        _gameMoves.Ended -= OnGameMovesEnded;
    }

    private void OnGameMovesEnded()
    {
        _animator.Play(_wakesUpAnimation);
    }
}
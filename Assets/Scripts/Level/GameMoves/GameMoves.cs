using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameMoves : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Image _inputHandler;
    [SerializeField] private UnityEvent _ended;

    [field: SerializeField] public int Count { get; private set; }

    public event Action Changed;
    public event Action Ended;

    private void OnEnable()
    {
        _player.Movement.FinishedMoving += FinishMove;
    }

    private void OnDisable()
    {
        _player.Movement.FinishedMoving -= FinishMove;
    }

    private void FinishMove()
    {
        Count--;
        Changed?.Invoke();
        _inputHandler.raycastTarget = true;

        if (Count == 0)
        {
            Ended?.Invoke();
            _ended?.Invoke();
        }
    }
}

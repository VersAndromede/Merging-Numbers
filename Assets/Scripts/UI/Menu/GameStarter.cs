using UnityEngine;
using UnityEngine.Events;

public class GameStarter : MonoBehaviour
{
    [SerializeField] private UnityEvent _playerWon;

    public void StartGame()
    {
        _playerWon?.Invoke();
    }
}

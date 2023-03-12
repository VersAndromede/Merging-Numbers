using TMPro;
using UnityEngine;

public class EndGameScreenView : MonoBehaviour
{
    [SerializeField] private GameOverController _victoryController;
    [SerializeField] private TextMeshProUGUI _text;

    private void OnEnable()
    {
        _victoryController.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _victoryController.GameOver -= OnGameOver;
    }
    
    private void OnGameOver(Winner winner)
    {
        if (winner == Winner.Player)
            _text.text = "Victory";
        else
            _text.text = "Defeat";
    }
}

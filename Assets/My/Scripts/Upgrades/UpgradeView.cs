using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeView : MonoBehaviour
{
    [SerializeField] private Upgrade _upgrade;
    [SerializeField] private TextMeshProUGUI _textPrice;
    [SerializeField] private TextMeshProUGUI _textLevel;
    [SerializeField] private Button _button;
    [SerializeField] private Slider _slider;

    private void OnEnable()
    {
        _upgrade.LevelChanged += OnLevelChanged;
    }

    private void Start()
    {
        OnLevelChanged();
    }

    private void OnDisable()
    {
        _upgrade.LevelChanged -= OnLevelChanged;
    }

    private void OnLevelChanged()
    {
        _slider.value = (float)_upgrade.Level / _upgrade.MaxLevel;

        if (_upgrade.CanImprove == false)
        {
            _textPrice.text = "-";
            _textLevel.text = "Макс. уровень";
            _button.interactable = false;
        }
        else
        {
            _textPrice.text = _upgrade.Price.ToString();
            _textLevel.text = $"{_upgrade.Level} уровень";
        }
    }
}
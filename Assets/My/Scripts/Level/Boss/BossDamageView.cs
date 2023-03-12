using TMPro;
using UnityEngine;

public class BossDamageView : MonoBehaviour
{
    [SerializeField] private BossLoader _bossLoader;
    [SerializeField] private TextMeshProUGUI _text;

    private void OnEnable()
    {
        _bossLoader.Loaded += OnBossLoaded;
    }

    private void OnDisable()
    {
        _bossLoader.Loaded -= OnBossLoaded;
    }

    private void OnBossLoaded(Boss boss)
    {
        _text.text = boss.Data.Damage.ToString();
    }
}

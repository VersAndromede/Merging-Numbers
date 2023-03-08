using TMPro;
using UnityEngine;

public class BossDamageView : MonoBehaviour
{
    [SerializeField] private Boss _boss;
    [SerializeField] private TextMeshProUGUI _text;

    private void Start()
    {
        _text.text = _boss.Damage.ToString();
    }
}

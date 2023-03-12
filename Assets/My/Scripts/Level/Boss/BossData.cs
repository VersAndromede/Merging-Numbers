using UnityEngine;

[CreateAssetMenu(fileName = "BossData")]
public class BossData : ScriptableObject
{
    [field: SerializeField] public int Health { get; private set; }
    [field: SerializeField] public int Damage { get; private set; }
    [field: SerializeField] public Color Color { get; private set; }
}
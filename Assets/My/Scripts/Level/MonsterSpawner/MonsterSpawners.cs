using UnityEngine;

public class MonsterSpawners : MonoBehaviour
{
    private MonsterSpawner[] _monsterSpawners;

    private void Start()
    {
        _monsterSpawners = GetComponentsInChildren<MonsterSpawner>();
    }

    public void TrySpawnOnlyPositiveMonsters()
    {
        foreach (MonsterSpawner monsterSpawner in _monsterSpawners)
            if (monsterSpawner.HasPlayerAtStart == false)
                monsterSpawner.SpawnOnlyPositive();
    }
}

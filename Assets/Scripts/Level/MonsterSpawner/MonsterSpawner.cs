using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private Monster _monsterPrefab;
    [SerializeField] private GameMoves _gameMoves;
    [SerializeField] private SpawnerObserver _observer;
    [SerializeField] private int _numberMovesToComplicate;
    [SerializeField] private int _powerProgression;
    [SerializeField] private int _startingMinPower;
    [SerializeField] private int _startingMaxPower;
    [SerializeField] private int _dividerPower;
    [Range(0, 100)] 
    [SerializeField] private int _probabilityPositiveMonster;
    [Range(0, 100)] 
    [SerializeField] private int _probabilityDividerMonster;

    [field: SerializeField] public bool HasPlayerAtStart { get; private set; }

    private Monster _currentMonster;

    private void OnEnable()
    {
        _gameMoves.Changed += TryRandomSpawn;
        _gameMoves.Changed += TryIncreaseDifficulty;
        _gameMoves.Ended += OnGameMovesEnded;
    }

    private void OnDisable()
    {
        _gameMoves.Changed -= TryRandomSpawn;
        _gameMoves.Changed -= TryIncreaseDifficulty;
        _gameMoves.Ended -= OnGameMovesEnded;
    }

    public void SpawnOnlyPositive()
    {
        _currentMonster = Instantiate(_monsterPrefab, transform);
        int power = Random.Range(_startingMinPower, _startingMaxPower);
        _currentMonster.Init(MonsterType.Adding, power);
    }

    private void TryRandomSpawn()
    {
        if (_observer.Monster != null || _observer.Player != null)
            return;

        _currentMonster = Instantiate(_monsterPrefab, transform);
        int power = Random.Range(_startingMinPower, _startingMaxPower);

        if (Randomizer.CheckProbability(_probabilityPositiveMonster))
        {
            _currentMonster.Init(MonsterType.Adding, power);
        }
        else
        {
            if (Randomizer.CheckProbability(_probabilityDividerMonster))
            {
                _currentMonster.Init(MonsterType.Divider, _dividerPower);
                return;
            }

            _currentMonster.Init(MonsterType.Adding, -power);
        }
    }

    private void TryIncreaseDifficulty()
    {
        if (_gameMoves.Count % _numberMovesToComplicate == 0)
        {
            _startingMinPower += _powerProgression;
            _startingMaxPower += _powerProgression;
        }
    }

    private void OnGameMovesEnded()
    {
        if (_currentMonster != null)
            _currentMonster.Die();
    }
}
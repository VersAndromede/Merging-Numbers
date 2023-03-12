using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameMoves _gameMoves;

    [field: SerializeField] public PlayerMovement Movement { get; private set; }
    [field: SerializeField] public Power Power { get; private set; }
    [field: SerializeField] public MonsterObserver Observer { get; private set; }
    [field: SerializeField] public Health Health { get; private set; }
    [field: SerializeField] public int Damage { get; private set; }

    private void OnEnable()
    {
        Movement.StartedMoving += OnStartedMoving;
        Power.Over += Die;
        Health.Died += Die;
        _gameMoves.Ended += OnGameMovesEnded;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Monster monster))
            Merge(monster);
    }

    private void OnDisable()
    {
        Movement.StartedMoving -= OnStartedMoving;
        Power.Over -= Die;
        Health.Died -= Die;
        _gameMoves.Ended -= OnGameMovesEnded;
    }

    public void UpdateDamage()
    {
        Damage += SaveSystem.Load().UpgradeDatas[0].BonusValue;
    }

    private void Merge(Monster monster)
    {
        Destroy(monster.gameObject);

        if (monster.Type == MonsterType.Adding)
            Power.Add(monster.Power.Value);
        else if (monster.Type == MonsterType.Divider)
            Power.Divide(monster.Power.Value);
    }

    private void OnStartedMoving()
    {
        Observer.Clear();
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void OnGameMovesEnded()
    {
        const int HealthMultiplier = 100;

        Health.Init(Power.Value * HealthMultiplier);
    }
}
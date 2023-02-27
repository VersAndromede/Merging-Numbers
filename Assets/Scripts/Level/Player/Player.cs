using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field: SerializeField] public PlayerMovement Movement { get; private set; }
    [field: SerializeField] public Power Power { get; private set; }
    [field: SerializeField] public MonsterObserver Observer { get; private set; }

    private void OnEnable()
    {
        Movement.StartedMoving += OnMoved;
        Power.Died += OnDied;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Monster monster))
            Merge(monster);
    }

    private void OnDisable()
    {
        Movement.StartedMoving -= OnMoved;
    }

    private void Merge(Monster monster)
    {
        Destroy(monster.gameObject);

        if (monster.Type == MonsterType.Adding)
            Power.Add(monster.Power.Value);
        else if (monster.Type == MonsterType.Divider)
            Power.Divide(monster.Power.Value);
    }

    private void OnMoved()
    {
        Observer.Clear();
    }

    private void OnDied()
    {
        Destroy(gameObject);
    }
}
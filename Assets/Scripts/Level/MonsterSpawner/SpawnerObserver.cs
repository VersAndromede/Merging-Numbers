using UnityEngine;

public class SpawnerObserver : MonoBehaviour
{
    public Player Player { get; private set; }
    public Monster Monster { get; private set; }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out Player player))
            Player = player;

        if (collision.TryGetComponent(out Monster monster))
            Monster = monster;
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent(out Player player))
            Player = null;

        if (collision.TryGetComponent(out Monster monster))
            Monster = null;
    }
}

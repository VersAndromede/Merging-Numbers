using System;
using UnityEngine;

public class Power : MonoBehaviour
{
    [field: SerializeField] public int Value { get; private set; }

    public event Action Changed;
    public event Action Died;

    public void Add(int count)
    {
        Value += count;
        Changed?.Invoke();
        TryDie();
    }

    public void Divide(int divider)
    {
        if (divider < 1)
            Debug.LogError("In this context it is incorrect to divide by a number less than 1.");

        Value /= divider;
        Changed?.Invoke();
        TryDie();
    }

    private void TryDie()
    {
        if (Value < 0)
            Died?.Invoke();
    }
}

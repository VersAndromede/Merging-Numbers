using UnityEngine;

public static class Randomizer
{
    public static bool CheckProbability(int probability)
    {
        if (probability < 0 || probability > 100)
            Debug.LogError("Probability must be in the range 0 - 100.");

        return probability >= Random.Range(0, 100);
    }
}
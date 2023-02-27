using System;

public static class Randomizer
{
    public static bool CheckProbability(int probability)
    {
        if (probability < 0 || probability > 100)
            throw new ArgumentOutOfRangeException("Probability must be in the range 0 - 100.");

        return probability >= UnityEngine.Random.Range(0, 100);
    }
}
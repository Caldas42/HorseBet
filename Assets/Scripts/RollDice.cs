using UnityEngine;

public class RollDice : MonoBehaviour
{
    private int lastRoll = 0;

    public void Roll()
    {
        lastRoll = Random.Range(1, 7);
        Debug.Log("Rolled: " + lastRoll);
    }

    public int GetLastRoll()
    {
        return lastRoll;
    }
}

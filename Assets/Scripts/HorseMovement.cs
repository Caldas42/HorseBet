using UnityEngine;
using System.Collections.Generic;

public class HorseMovement : MonoBehaviour
{
    [SerializeField] private List<Transform> apples;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private RollDice dice;

    private int currentIndex = 0;
    private int previousIndex = 0;
    private int steps = 0;
    private bool doubled = false;
    private bool isMoving = false;
    private Vector3 targetPosition;

    void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                isMoving = false;

                if (currentIndex > previousIndex)
                {
                    for (int i = previousIndex + 1; i <= currentIndex; i++)
                    {
                        if (apples[i] != null)
                            apples[i].gameObject.SetActive(false);
                    }
                } else if (currentIndex < previousIndex)
                {
                    for (int i = currentIndex + 1; i <= previousIndex; i++)
                    {
                        if (apples[i] != null)
                            apples[i].gameObject.SetActive(true);
                    }
                }

                previousIndex = currentIndex;
            }
        }
    }

    public void MoveHorse()
    {
        if (doubled && (dice.GetLastRoll() == 3 || dice.GetLastRoll() == 4 || dice.GetLastRoll() == 5))
        {
            steps += dice.GetLastRoll() * 2;
            doubled = false;
        } else
        {
            steps += dice.GetLastRoll();
        }

        if (steps != 0)
        {
            currentIndex += steps;
            steps = 0;

            if (currentIndex < 0)
                currentIndex = 0;

            if (currentIndex >= apples.Count)
                currentIndex = apples.Count - 1;

            targetPosition = apples[currentIndex].position;

            isMoving = true;
        }
    }

    public void PlusTwo()
    {
        steps += 2;
    }

    public void MinusTwo()
    {
        steps -= 2;
    }

    public void DoubleThreeFourFive()
    {
        doubled = true;
    }

    public int GetCurrentIndex()
    {
        return currentIndex;
    }

    public int GetApplesCount()
    {
        return apples.Count;
    }
}

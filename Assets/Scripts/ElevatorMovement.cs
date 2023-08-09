using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMovement : MonoBehaviour
{

    [SerializeField] private float speed = 2f;

    [SerializeField] private List<GameObject> targetPoints;
    private int currentTargetPointIndex;
    private GameObject nextTarget;

    void Start()
    {
        if (targetPoints.Count > 0)
        {
            nextTarget = targetPoints[0];

        }
    }

    void FixedUpdate()
    {
        if (nextTarget != null)
        {
            MoveToPosition(nextTarget);

        }

    }
    private void MoveToPosition(GameObject moveToTarget)
    {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, moveToTarget.transform.position, speed * Time.fixedDeltaTime);
        if (gameObject.transform.position == moveToTarget.transform.position)
        {
            ChangeTargets();
        }

    }

    private void ChangeTargets()
    {
        currentTargetPointIndex++;

        while (targetPoints[currentTargetPointIndex] == null)
        {
            currentTargetPointIndex++;
            if (currentTargetPointIndex >= targetPoints.Count)
            {
                currentTargetPointIndex = 0;
            }
        }

        nextTarget = targetPoints[currentTargetPointIndex];
    }
}

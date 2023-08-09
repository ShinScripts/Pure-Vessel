using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    private Vector3 position;
    private Vector3 target;
    private float speed = 1;

    private void Update()
    {
        position = transform.position;
        target = GameObject.Find("Player").transform.position;
        float step = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(position, target, step);
    }
}

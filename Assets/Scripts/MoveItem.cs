using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveItem : MonoBehaviour
{
    public Vector3 direction;
    public float timeToDestroy;

    private void Update()
    {
        gameObject.transform.Translate(direction * Time.deltaTime);
        Destroy(gameObject, timeToDestroy);
    }
}

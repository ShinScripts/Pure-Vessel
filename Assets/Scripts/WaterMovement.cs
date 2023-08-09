using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour
{
    [SerializeField] private float scrollSpeed, tileSize;

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSize);
        gameObject.transform.position = new Vector3(newPosition, gameObject.transform.position.y, 0);
    }
}

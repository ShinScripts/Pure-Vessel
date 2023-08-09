using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2 : MonoBehaviour
{

    [SerializeField] private GameObject playerObject;
    [SerializeField] private float smoothSpeed = 0.1f;
    [SerializeField] private float leftLockValue;
    [SerializeField] private float rightLockValue;
    private Vector3 offset = new Vector3(0f, 0.5f, -5f);


    void Start()
    {
        playerObject = GameObject.Find("Player");

    }

    void FixedUpdate()
    {

        Vector3 desiredPosition = playerObject.transform.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(gameObject.transform.position, desiredPosition, smoothSpeed * Time.fixedDeltaTime);
        gameObject.transform.position = smoothPosition;

        Vector3 position = gameObject.transform.position;
        if (gameObject.transform.position.x <= leftLockValue)
        {
            gameObject.transform.position = new Vector3(leftLockValue, position.y, position.z);
        }

        if (gameObject.transform.position.x >= rightLockValue)
        {
            gameObject.transform.position = new Vector3(rightLockValue, position.y, position.z);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowFinal : MonoBehaviour
{

    [SerializeField] private GameObject playerObject;
    [SerializeField] private float smoothSpeed = 0.1f;
    [SerializeField] private float leftLockValue;
    [SerializeField] private float rightLockValue;
    private Vector3 offset = new Vector3(0f, .9f, -5f);
    private bool hasTransitioned = false;


    void Start()
    {
        playerObject = GameObject.Find("Player");
        gameObject.GetComponent<Camera>().orthographicSize = 1.5f;
    }



    void FixedUpdate()
    {
        if (playerObject.GetComponent<PlayerMovement>().hasTouchedGroundOnce)
        {
            smoothSpeed = 40;
        }

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

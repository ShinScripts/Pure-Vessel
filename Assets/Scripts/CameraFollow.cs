using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private GameObject playerObject;
    [SerializeField] private float smoothSpeed = 0.1f;
    [SerializeField] private float leftLockValue;
    [SerializeField] private float rightLockValue;
    private Vector3 offset = new Vector3(0f, 1.6f, -5f);
    private bool hasTransitioned = false;


    void Start()
    {
        playerObject = GameObject.Find("Player");
        offset = new Vector3(0f, -0.7f, -5f);
        gameObject.GetComponent<Camera>().orthographicSize = 1.5f;
    }

    private void Update()
    {
        if (playerObject.GetComponent<PlayerMovement>().hasTouchedGroundOnce && !hasTransitioned)
        {
            hasTransitioned = true;
            StartCoroutine(CameraTransition());
        }
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

    private IEnumerator CameraTransition()
    {
        float duration = 1;
        float currentTime = 0;
        while (currentTime < duration)
        {
            float zoom = Mathf.Lerp(1.5f, 2.5f, currentTime / duration);
            float offsetY = Mathf.Lerp(0f, 1.6f, currentTime / duration);

            gameObject.GetComponent<Camera>().orthographicSize = zoom;
            offset = new Vector3(0f, offsetY, -5f);

            currentTime += Time.deltaTime;
            yield return null;
        }
        yield break;
    }
}

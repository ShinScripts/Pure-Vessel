using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMusic : MonoBehaviour
{
    public GameObject playerObject;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerObject.GetComponent<PlayerMovement>().hasTouchedGroundOnce)
        {
            gameObject.GetComponent<AudioSource>().Play();
            enabled = false;
        }
    }
}

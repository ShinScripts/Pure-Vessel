using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Enable : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
        gameObject.GetComponent<Canvas>().enabled = false;
    }

    private void Update()
    {
        gameObject.GetComponent<Canvas>().enabled = player.GetComponent<PlayerMovement>().hasTouchedGroundOnce;
    }
}

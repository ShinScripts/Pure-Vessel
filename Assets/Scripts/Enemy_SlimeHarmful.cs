using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SlimeHarmful : MonoBehaviour
{
    [SerializeField] private int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerState>().DoHarm(damage);
        }
    }
}

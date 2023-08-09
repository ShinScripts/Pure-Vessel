using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Coin : MonoBehaviour

{
    [SerializeField] private float timeBeforeDestruction;
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip pickupClip;

    private bool isTaken = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isTaken)
        {
            collision.GetComponent<PlayerState>().CoinPickup();
            audioSource.pitch = Random.Range(0.9f, 1.1f);
            particles.Play();
            audioSource.PlayOneShot(pickupClip);

            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            isTaken = true;
            Destroy(gameObject, timeBeforeDestruction);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class PlayerCheckPoint : MonoBehaviour
{
    private bool hasPlayed;

    [SerializeField] private AudioClip audioClip;
    [SerializeField] private GameObject videoClip;
    [SerializeField] private GameObject UI_Video;
    [SerializeField] private RenderTexture renderTexture;

    private void Start()
    {
        try
        {
            renderTexture.Release();
        }
        catch { }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasPlayed)
        {
            hasPlayed = true;
            collision.GetComponent<PlayerState>().ChangeRespawnPosition(gameObject);
            gameObject.GetComponent<AudioSource>().PlayOneShot(audioClip);

            StartCoroutine(waiter());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.GetComponent<AudioSource>().enabled = false;

        }
    }

    IEnumerator waiter()
    {
        videoClip.GetComponent<VideoPlayer>().Play();
        UI_Video.SetActive(true);
        yield return new WaitForSeconds((float)videoClip.GetComponent<VideoPlayer>().length);
        UI_Video.SetActive(false);
    }
}






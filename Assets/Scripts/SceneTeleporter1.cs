using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTeleporter1 : MonoBehaviour
{
    private bool hasEntered = false;
    [SerializeField] private GameObject objecteffect1;
    [SerializeField] private GameObject objecteffect2;

    [System.Obsolete]
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasEntered)
        {
            hasEntered = true;
            StartCoroutine(Teleporter(4f));
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

    [System.Obsolete]
    private void OnTriggerExit2D(Collider2D collision)
    {
        hasEntered = false;
        StopAllCoroutines();

        objecteffect1.GetComponent<ParticleSystem>().Stop();
        objecteffect2.GetComponent<ParticleSystem>().Stop();

        StartCoroutine(Fade(objecteffect1.GetComponent<ParticleSystem>(), 1, 0, 1));
        StartCoroutine(Fade(objecteffect2.GetComponent<ParticleSystem>(), 1, 0, 1));
        gameObject.GetComponent<AudioSource>().Stop();

    }

    private IEnumerator Teleporter(float seconds)
    {
        objecteffect1.GetComponent<ParticleSystem>().Play(); //move from y=-160 to y=-64.42
        objecteffect2.GetComponent<ParticleSystem>().Play();

        yield return new WaitForSeconds(seconds);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        objecteffect1.GetComponent<ParticleSystem>().Stop();
        objecteffect2.GetComponent<ParticleSystem>().Stop();
    }


    [System.Obsolete]
    private IEnumerator Fade(ParticleSystem particles, float from, float to, float duration)
    {
        yield return new WaitForSeconds(2.5f);

        float currentTime = 0;
        while (currentTime < duration)
        {
            float alpha = Mathf.Lerp(from, to, currentTime / duration);
            particles.startColor = new Color(particles.startColor.r, particles.startColor.g, particles.startColor.b, alpha);
            currentTime += Time.deltaTime;
            yield return null;
        }
        yield break;
    }
}


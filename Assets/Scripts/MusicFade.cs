using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicFade : MonoBehaviour
{
    private AudioSource[] sources;

    private void Start()
    {
        sources = gameObject.GetComponents<AudioSource>();

        foreach (AudioSource source in sources)
        {
            source.volume = 0;
        }

        StartCoroutine(Fade());
        StartCoroutine(FadeOutAmbience());
    }

    private IEnumerator Fade()
    {
        yield return new WaitForSeconds(1);

        float duration = 5;
        float currentTime = 0;

        while (currentTime < duration)
        {
            float mainVolume = Mathf.Lerp(0, 1, currentTime / duration);
            float volume2 = Mathf.Lerp(0, .3f, currentTime / duration);
            float volume3 = Mathf.Lerp(0, .5f, currentTime / duration);

            foreach (AudioSource source in sources)
            {
                if (source.clip.name == "353501__inspectorj__ambience-wind-chimes-a")
                {
                    source.volume = volume2;
                }
                else if (source.clip.name == "rain_medium")
                {
                    source.volume = volume3;
                }
                else
                {
                    source.volume = mainVolume;
                }
            }

            currentTime += Time.deltaTime;
            yield return null;
        }
        yield break;
    }

    private IEnumerator FadeOutAmbience()
    {
        yield return new WaitForSeconds(8);

        float duration = 3;
        float currentTime = 0;

        while (currentTime < duration)
        {
            float volume = Mathf.Lerp(.3f, 0, currentTime / duration);

            foreach (AudioSource source in sources)
            {
                if (source.clip.name == "353501__inspectorj__ambience-wind-chimes-a")
                    source.volume = volume;
            }

            currentTime += Time.deltaTime;
            yield return null;
        }
        yield break;
    }
}

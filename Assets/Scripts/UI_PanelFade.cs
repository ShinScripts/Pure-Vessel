using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PanelFade : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] MainMenuScripts mainMenuScripts;
    private bool triggered = false;

    private void Start()
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
        StartCoroutine(FadeIn());
    }

    private void Update()
    {
        if (mainMenuScripts.switchingScenes && !triggered)
        {
            triggered = true;
            StartCoroutine(FadeOut());
        }
    }

    private IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(1);

        float duration = 2;
        float currentTime = 0;
        while (currentTime < duration)
        {
            float alpha = Mathf.Lerp(1, 0, currentTime / duration);
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
            currentTime += Time.deltaTime;
            yield return null;
        }
        gameObject.GetComponent<Image>().enabled = false;
        yield break;
    }

    private IEnumerator FadeOut()
    {
        gameObject.GetComponent<Image>().enabled = true;

        yield return new WaitForSeconds(1);

        float duration = 2;
        float currentTime = 0;
        while (currentTime < duration)
        {
            float alpha = Mathf.Lerp(0, 1, currentTime / duration);
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
            currentTime += Time.deltaTime;
            yield return null;
        }
        yield break;
    }
}

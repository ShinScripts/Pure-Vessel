using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_FadeInButtons : MonoBehaviour
{
    private float delay = 4f;
    private bool isDone = false;

    [System.Obsolete]
    private void Start()
    {
        foreach (Image button in gameObject.GetComponentsInChildren<Image>())
        {
            button.color = new Color(button.color.r, button.color.g, button.color.b, 0);
            button.GetComponentInChildren<Text>().color = new Color(button.GetComponentInChildren<Text>().color.r, button.GetComponentInChildren<Text>().color.g, button.GetComponentInChildren<Text>().color.b, 0);
        }

        foreach (Image child in gameObject.GetComponentsInChildren<Image>())
        {
            StartCoroutine(FadeButtons(child, delay));
            delay += .3f;
        }
    }

    private void Update()
    {
        if (isDone)
        {
            foreach (Image button in gameObject.GetComponentsInChildren<Image>())
            {
                button.color = new Color(button.color.r, button.color.g, button.color.b, 0);
                button.GetComponentInChildren<Text>().color = new Color(button.GetComponentInChildren<Text>().color.r, button.GetComponentInChildren<Text>().color.g, button.GetComponentInChildren<Text>().color.b, 1);
            }
        }
    }

    [System.Obsolete]
    private IEnumerator FadeButtons(Image button, float delay)
    {
        yield return new WaitForSeconds(delay);

        float duration = 3;
        float currentTime = 0;
        Text textColor = button.GetComponentInChildren<Text>();

        while (currentTime < duration)
        {
            float alpha = Mathf.Lerp(0, 1, currentTime / duration);

            button.color = new Color(button.color.r, button.color.g, button.color.b, alpha);
            textColor.color = new Color(textColor.color.r, textColor.color.g, textColor.color.b, alpha);

            currentTime += Time.deltaTime;
            yield return null;
        }
        isDone = true;
        yield break;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_TextFade : MonoBehaviour
{
    [SerializeField] private Text text;

    private void Start()
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        StartCoroutine(Fade());
    }

    private IEnumerator Fade()
    {
        yield return new WaitForSeconds(2.5f);

        float duration = 3;
        float currentTime = 0;
        while (currentTime < duration)
        {
            float alpha = Mathf.Lerp(0, 1, currentTime / duration);
            text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
            currentTime += Time.deltaTime;
            yield return null;
        }
        yield break;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_DashBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    private GameObject player;
    private bool wait = false;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (player.GetComponent<PlayerMovement>().hasDashed && !wait)
        {
            wait = true;
            StartCoroutine(RefillBar());
        }

    }

    private IEnumerator RefillBar()
    {
        float duration = 1;
        float currentTime = 0;

        while (currentTime < duration)
        {
            float level = Mathf.Lerp(0, 1, currentTime / duration);

            slider.value = level;

            currentTime += Time.deltaTime;
            yield return null;
        }
        wait = false;

        yield break;
    }
}

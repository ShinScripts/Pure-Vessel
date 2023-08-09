using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScripts : MonoBehaviour
{
    [SerializeField] private GameObject credits;
    [SerializeField] private GameObject buttons;
    public bool switchingScenes = false;

    public void PlayGame()
    {
        StartCoroutine(SwitchScene());
    }

    public void GoToCredits()
    {
        buttons.SetActive(false);
        credits.SetActive(true);
    }

    public void GoFromCredits()
    {
        buttons.SetActive(true);
        credits.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private IEnumerator SwitchScene()
    {
        switchingScenes = true;
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        yield return null;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_StartGame : MonoBehaviour
{
    public void StartGame()
    {
        // PlayerPrefs.SetInt("Coin Amount", 0);
        SceneManager.LoadScene(1);
    }
}

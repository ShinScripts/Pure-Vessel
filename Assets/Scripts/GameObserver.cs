using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObserver : MonoBehaviour
{
    public static void SaveCoinsToMemory(int amount)
    {
        PlayerPrefs.SetInt("Coin Amount", PlayerPrefs.GetInt("Coin Amount") + amount);
    }
}

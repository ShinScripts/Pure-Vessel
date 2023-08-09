using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quest_DoorToNextLevel : MonoBehaviour
{

    [SerializeField] int levelToLoad;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<Quest_Player>().isQuestComplete == true)
            {
                GameObserver.SaveCoinsToMemory(collision.GetComponent<PlayerState>().coinAmount);
                SceneManager.LoadScene(levelToLoad);

            }
        }
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Quest_Giver : MonoBehaviour
{
    [SerializeField] private Text textComponent;
    [SerializeField] private Image panel;

    [SerializeField] private List<string> questText;
    public bool hasSaidEverything;
    private bool hasSaidEverythingOnce;
    [SerializeField] private string questCompleteText;

    [SerializeField] private GameObject doorToOpenWhenQuestIsComplete;
    private Animator animator;

    public bool isReadingQuest = false;
    public GameObject scenePortals;

    public GameObject turnOFFPPC;
    public GameObject turnOnPPC;

    public GameObject turnOFFShrineGlow;
    public GameObject turnOnShrineGlow;

    private int index = 0;

    void Start()
    {
        Components(false);
        textComponent.text = questText[index];
        animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (index < questText.ToArray().Length)
        {
            textComponent.text = questText[index];
        }

        if (isReadingQuest && !hasSaidEverything)
        {
            Components(true);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                index++;

                if (index >= questText.ToArray().Length)
                {
                    Components(false);
                    isReadingQuest = false;
                    hasSaidEverything = true;
                }
            }
        }
        if (hasSaidEverything && !hasSaidEverythingOnce)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            animator.SetTrigger("OpenPortal");
            hasSaidEverythingOnce = true;
            turnOFFPPC.SetActive(false);
            turnOnPPC.SetActive(true);
            scenePortals.SetActive(true);
            turnOFFShrineGlow.SetActive(false);
            turnOnShrineGlow.SetActive(true);
            gameObject.GetComponent<AudioSource>().Play();


        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isReadingQuest = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isReadingQuest = false;
            index = 0;
            Components(false);

        }

    }

    private void Components(bool status)
    {
        panel.enabled = status;
        textComponent.enabled = status;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard_PlayerDetection : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject spawnPos;

    public bool isTriggered = false;
    private GameObject player, wizard;

    private void Start()
    {
        player = GameObject.Find("Player");
        wizard = GameObject.Find("Wizard");
    }

    private void Update()
    {
        if (!wizard.GetComponent<Wizard_Movement>().isAlive)
            StopAllCoroutines();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isTriggered = true;
            StartCoroutine(SpawnShot(2f));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isTriggered = false;
            StopAllCoroutines();
        }
    }

    private IEnumerator SpawnShot(float cooldown)
    {
        while (isTriggered)
        {
            wizard.GetComponent<Animator>().SetTrigger("isAttacking");

            if (!wizard.GetComponent<Wizard_Movement>().isFacingRight)
            {
                GameObject shot = Instantiate(projectile, spawnPos.transform.position, Quaternion.identity);
                GameObject shot2 = Instantiate(projectile, spawnPos.transform.position, Quaternion.identity);
                GameObject shot3 = Instantiate(projectile, spawnPos.transform.position, Quaternion.identity);

                shot.GetComponent<MoveItem>().direction.x *= 2;
                shot2.GetComponent<MoveItem>().direction.x *= 2;
                shot3.GetComponent<MoveItem>().direction.x *= 2;

                shot2.GetComponent<MoveItem>().direction.y += 2;
                shot3.GetComponent<MoveItem>().direction.y -= 2;
            }
            else
            {
                GameObject shot = Instantiate(projectile, spawnPos.transform.position, Quaternion.identity);
                GameObject shot2 = Instantiate(projectile, spawnPos.transform.position, Quaternion.identity);
                GameObject shot3 = Instantiate(projectile, spawnPos.transform.position, Quaternion.identity);

                shot.GetComponent<MoveItem>().direction.x *= -2;
                shot2.GetComponent<MoveItem>().direction.x *= -2;
                shot3.GetComponent<MoveItem>().direction.x *= -2;

                shot2.GetComponent<MoveItem>().direction.y += 2;
                shot3.GetComponent<MoveItem>().direction.y -= 2;
            }

            yield return new WaitForSeconds(cooldown);
        }
    }
}

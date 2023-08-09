using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDestroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Destructible"))
        {
            StartCoroutine(Attack(collision.gameObject));
        }
    }

    private IEnumerator Attack(GameObject objectToDestroy)
    {
        try
        {
            objectToDestroy.GetComponent<CircleCollider2D>().enabled = false;
        }
        catch { }

        yield return new WaitForSeconds(.2f);
        Destroy(objectToDestroy);
    }
}

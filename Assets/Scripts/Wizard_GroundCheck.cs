using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard_GroundCheck : MonoBehaviour
{
    private Wizard_Movement wizardMovement;

    private void Start()
    {
        wizardMovement = GameObject.Find("Wizard").GetComponent<Wizard_Movement>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            wizardMovement.isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            wizardMovement.isGrounded = false;
        }
    }
}

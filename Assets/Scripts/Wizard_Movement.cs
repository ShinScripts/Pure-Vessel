using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard_Movement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private float movementDirection = 1f;
    [SerializeField] private int lives = 5;

    private Rigidbody2D rigidBody2D;

    private Animator animator;

    public GameObject groundCheck, bossCollider;

    public bool isGrounded;
    public bool isFacingRight = false;
    public bool isAlive = true;

    public GameObject playerObject;

    public GameObject finalSceneportal;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        bossCollider = GameObject.Find("BossCollider");
        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        animator.SetBool("isMoving", bossCollider.GetComponent<Wizard_PlayerDetection>().isTriggered);

        if (bossCollider.GetComponent<Wizard_PlayerDetection>().isTriggered)
        {
            if (isGrounded && isAlive)
            {
                Vector3 newPosition = gameObject.transform.position;
                newPosition.x += (speed * Time.fixedDeltaTime) * movementDirection;
                rigidBody2D.MovePosition(newPosition);
            }
        }

        if (!isGrounded && isAlive)
        {
            ChangeDirection();
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        movementDirection = -movementDirection;

        if (movementDirection > 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            isFacingRight = true;
        }
        else
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            isFacingRight = false;
        }
    }

    public void KillMe()
    {

        isAlive = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;       //goes into object (slime)'s component boxcollidor2d. Then in its properties finds "enabled" and sets it so false. (this disables the slimes boxcollider)
        Vector2 killForce = new Vector2(movementDirection, 4f);
        rigidBody2D.AddForce(killForce, ForceMode2D.Impulse); //what this?
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, -gameObject.transform.localScale.y);

        finalSceneportal.SetActive(true);
        gameObject.GetComponent<AudioSource>().Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("attackcollider"))
        {
            lives--;

            if (lives <= 0)
            {
                KillMe();
            }
        }
    }
}

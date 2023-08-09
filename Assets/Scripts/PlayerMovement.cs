using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject groundCheck;
    [SerializeField] private GameObject attackCollider;
    private Animator animator;

    public float movementSpeed = 2f;
    private float defaultMovementSpeed;
    [SerializeField] private int jumpPower = 200;
    [SerializeField] private int dashForce = 1000;

    public bool isGrounded = false;
    private Vector3 velocity;
    private SpriteRenderer spriteRenderer;
    private bool isFacingLeft = false;

    public bool hasTouchedGroundOnce = false;
    private bool canMoveAround = false;

    private float moveDirection = 0f;
    private bool isJumpPresssed = false;
    private bool hasDoubleJumped = false;
    public bool hasDashed = false;
    private float megaJump = 2f;
    [SerializeField] private GameObject questHolder;

    public AudioSource audioSource;

    void Start()
    {
        defaultMovementSpeed = movementSpeed;
        rb = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
        FlipPlayer();
    }

    private void Update()
    {
        if (isGrounded)
        {
            if (!hasTouchedGroundOnce)
            {
                canMoveAround = true;
                hasTouchedGroundOnce = true;
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 4;
            }
            hasDoubleJumped = false;
        }

        moveDirection = Input.GetAxis("Horizontal");

        if (canMoveAround)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && !hasDashed || Input.GetMouseButtonDown(1) && !hasDashed)
            {
                StartCoroutine(Dash(new Vector3(2, 0, 0), 1f));
                animator.SetTrigger("DoDash");
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                isJumpPresssed = true;
                animator.SetTrigger("DoJump");
            }

            try
            {
                if (Input.GetMouseButtonDown(0) && !questHolder.GetComponent<Quest_Giver>().isReadingQuest)
                {

                    animator.SetTrigger("DoAttack");
                    StartCoroutine(Attack(.5f));
                }
            }
            catch
            {
                animator.SetTrigger("DoAttack");
                StartCoroutine(Attack(.5f));
            }

        }

        animator.SetBool("IsGrounded", isGrounded);
        animator.SetFloat("Speed", Mathf.Abs(moveDirection));
        animator.SetBool("isFalling", IsFalling());
    }

    private void FixedUpdate()
    {
        if (canMoveAround)
        {
            Vector3 calculateMovement = Vector3.zero;

            calculateMovement.x = movementSpeed * 150 * moveDirection * Time.fixedDeltaTime;
            calculateMovement.y = (!isGrounded) ? rb.velocity.y : 0f;
            MovePlayer(calculateMovement, isJumpPresssed);
        }

        isJumpPresssed = false;
    }

    private void MovePlayer(Vector3 moveDirection, bool isJumpPresssed)
    {
        rb.velocity = Vector3.SmoothDamp(rb.velocity, moveDirection, ref velocity, .05f);

        if (isJumpPresssed && !hasDoubleJumped && !isGrounded)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(transform.up * jumpPower);
            hasDoubleJumped = true;
        }
        else if (isJumpPresssed && isGrounded)
        {
            rb.AddForce(transform.up * jumpPower);
        }

        if (moveDirection.x > 0f && isFacingLeft)
        {
            FlipPlayer();
        }
        else if (moveDirection.x < 0f && !isFacingLeft)
        {
            FlipPlayer();
        }
    }

    IEnumerator Dash(Vector3 distance, float cooldown)
    {
        hasDashed = true;
        audioSource.pitch = Random.Range(0.9f, 1.1f);

        gameObject.GetComponent<AudioSource>().Play();

        rb.AddForce(((isFacingLeft) ? Vector3.left : Vector3.right) * dashForce);

        yield return new WaitForSeconds(cooldown);
        gameObject.GetComponent<AudioSource>().Stop();

        hasDashed = false;

        yield return null;
    }

    IEnumerator Attack(float duration)
    {
        attackCollider.SetActive(true);
        attackCollider.GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(duration);

        attackCollider.SetActive(false);

        yield return null;
    }

    private void FlipPlayer()
    {
        if (!isFacingLeft)
        {
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            isFacingLeft = !isFacingLeft;
        }
        else
        {
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            isFacingLeft = !isFacingLeft;
        }
    }

    public bool IsFalling()
    {
        if (rb.velocity.y < -1f)
        {
            return true;
        }
        return false;
    }

    public void ResetMovementSpeed()
    {
        movementSpeed = defaultMovementSpeed;
    }

    public void SetNewMovementSpeed(float newMovementSpeed)
    {
        movementSpeed += newMovementSpeed;
    }
}
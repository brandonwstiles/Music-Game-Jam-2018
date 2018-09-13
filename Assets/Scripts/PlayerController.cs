using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Values")]
    public float moveSpeed;
    public float jumpForce;
    private int extraJumpsCurrent;
    public int extraJumpsMax;
    public float fallMultiplier;
    private Vector2 moveInput;

    [Header("Ground Detection")]
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    //[SerializeField]
    private bool isGrounded;


    private Rigidbody2D rbody;
    private SpriteRenderer spriteRenderer;

    private bool facingRight = true;

    private void Start()

    {
        rbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        moveInput = Vector2.zero;
    }

    private void Update()
    {
        if (isGrounded)
            extraJumpsCurrent = extraJumpsMax;

        if (Input.GetKey(KeyCode.Space))
            moveInput.y = 1;
    }

    private void FixedUpdate()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        //Try this: moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        rbody.velocity = new Vector2(moveInput.x * moveSpeed, rbody.velocity.y);

        if (rbody.velocity.y < 0)
            rbody.velocity = new Vector2(rbody.velocity.x, rbody.velocity.y * fallMultiplier);

        if (Input.GetKeyDown(KeyCode.Space) && extraJumpsCurrent > 0)
        {
            rbody.velocity = new Vector2(rbody.velocity.x, 0);
            rbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            extraJumpsCurrent--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumpsCurrent == 0 && isGrounded)        
            rbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);


        if (facingRight && moveSpeed < 0)
            spriteRenderer.flipX = true;
        else if (!facingRight && moveSpeed > 0)
            spriteRenderer.flipX = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
            SceneManager.LoadScene("SideScroller");
    }
}

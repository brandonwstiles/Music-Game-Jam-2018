using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce = 5f;
    public float jumpSpeedAdjust = 2.5f;
    public float maxJumpTime = 0.35f;
    public bool isDead;

    float currentJumpTime;
    bool isGrounded;
    bool isJumping;
    Rigidbody2D rbody;

    private void Start()
    {
        rbody = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate ()
    {
        rbody.velocity += Vector2.up * Physics.gravity.y * jumpSpeedAdjust * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            isJumping = true;
            currentJumpTime = maxJumpTime;
            rbody.velocity = Vector2.up * jumpForce;
        }
        /*
        if(Input.GetKey(KeyCode.Space) && isJumping)
        {
            if (currentJumpTime > 0)
            {
                rbody.velocity = Vector2.up * jumpForce;
                currentJumpTime -= Time.deltaTime;
            }
            else
                isJumping = false;
        }
        
        if (Input.GetKeyUp(KeyCode.Space))
            isJumping = false;
        */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameObject.SetActive(false);
            isDead = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Object Tag: " + collision.gameObject.tag);
        print("Object name: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Platform"))
            isGrounded = true;
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameObject.SetActive(false);
            isDead = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
            isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
            isGrounded = false;
    }
}

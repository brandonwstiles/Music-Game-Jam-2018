using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpForce = 100f;

    public bool isGrounded;
    Rigidbody2D rbody;

    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //if (rbody.velocity.y < 0)
            //rbody.velocity = new Vector2(0, -jumpForce * 1.5f *Time.deltaTime);
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
                print("JUMP!!!");
            rbody.velocity = new Vector2(rbody.velocity.x, jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
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

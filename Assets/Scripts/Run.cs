using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour {

    public float runSpeed  = 10f;

    Rigidbody2D rbody;

    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
       
    }

    private void FixedUpdate()
    {
        rbody.velocity = new Vector2(runSpeed, rbody.velocity.y);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainMovement : MonoBehaviour {

    public float moveSpeed = 3f;
    Rigidbody2D rbody;

    private void Start()
    {
        rbody = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update ()
    {
        rbody.velocity = new Vector2(-moveSpeed, 0);
	}
}

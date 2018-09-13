using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainMovement : MonoBehaviour {

    public float moveSpeed = 3f;

    private void Start()
    {
    }

    void Update ()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x - 1, transform.position.y), moveSpeed);
	}
}

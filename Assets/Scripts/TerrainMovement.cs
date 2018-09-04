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
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, transform.position.y + 1), moveSpeed);
	}
}

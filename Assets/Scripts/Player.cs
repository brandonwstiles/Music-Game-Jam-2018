using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveDistance;
    public float moveSpeed;
    public bool isDead;

    Vector2 targetPos;
    
    private void Start()
    {
        targetPos = transform.position;
    }

    void FixedUpdate ()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, moveSpeed);
        if (targetPos.x % moveDistance != 0)
            targetPos.x = 0;

        if (Input.GetKeyDown(KeyCode.A) && targetPos.x > -moveDistance * 2)
        {
            targetPos = new Vector2(transform.position.x - moveDistance, transform.position.y);
        }

        if (Input.GetKeyDown(KeyCode.D) && targetPos.x < moveDistance * 2)
        {
            targetPos = new Vector2(transform.position.x + moveDistance, transform.position.y);
        }

    }

}

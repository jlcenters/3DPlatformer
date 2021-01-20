using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    public float speed;
    public Vector3 moveDirection;
    public float moveDistance;

    private Vector3 startPos;
    private bool movingToStart;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // are we moving to the start?
        if (movingToStart)
        {
            // overtime move towards the start position
            transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);

            // have we reached the target?
            if (transform.position == startPos)
            {
                movingToStart = false;
            }
        }
        // are we moving away from the start?
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos + (moveDirection * moveDistance), speed * Time.deltaTime);

            if (transform.position == startPos + (moveDirection * moveDistance))
            {
                movingToStart = true;
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 destination;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // left mouse click
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            destination.y = transform.position.y; // Stick to floor
    
        }

        float moveDistance = destination.x - transform.position.x;
        if (Mathf.Abs(moveDistance) > speed * Time.deltaTime)
        {
            moveDistance = Mathf.Sign(moveDistance) * speed * Time.deltaTime;
        }
        else
        {
            moveDistance = 0; // Prevent tiny jittering movement
        }
        transform.position += new Vector3(moveDistance, 0, 0);
    }
}

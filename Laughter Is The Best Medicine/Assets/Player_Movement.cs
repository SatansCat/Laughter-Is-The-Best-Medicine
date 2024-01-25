using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float speed = .5f;

    Rigidbody2D rBody2D;

    Vector2 movement;

    void Start()
    {
        if (GetComponent<Rigidbody2D>())
            rBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rBody2D.MovePosition(rBody2D.position + movement * speed * Time.deltaTime);
    }
}

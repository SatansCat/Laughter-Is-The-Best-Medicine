using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player_Controller : MonoBehaviour
{
    Rigidbody2D rBody2D;

    //Variables for movement
    public float speed = 2f;
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

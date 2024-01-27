using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float speed = .5f;

    Rigidbody2D rBody2D;
    Animator animator;

    Vector2 movement;

    void Start()
    {
        if (GetComponent<Rigidbody2D>())
            rBody2D = GetComponent<Rigidbody2D>();

        if (GetComponent<Animator>())
            animator = GetComponent<Animator>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        rBody2D.MovePosition(rBody2D.position + movement * speed * Time.deltaTime);
    }
}

using System.Collections.Generic;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Dependency")]
    [SerializeField] Transform self;
    [SerializeField] Rigidbody2D body;

    [Header("Movement")]
    public Vector2 moveValue;
    public Vector2 lastDir;
    [SerializeField] bool moving;

    [Header("Parameter")]
    [SerializeField] float speed = 10f;
    public void Movement(InputAction.CallbackContext context)
    {
        moveValue = context.ReadValue<Vector2>();
        if (moveValue.magnitude > 1f)
        {
            moveValue.Normalize();
        }
        if(moveValue.magnitude > 0.1f)
        {
            lastDir = moveValue.normalized;
        }

        moving = moveValue != Vector2.zero;
    }

    void Awake()
    {
        self = transform;
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!moving) return;

        if(Vector2.Dot(moveValue.normalized, body.velocity.normalized) >0)
        {
            body.velocity += moveValue * speed * Time.deltaTime;
        }
        else
        {
            body.velocity += moveValue * speed * Time.deltaTime;
        }
    }
}

using System.Collections.Generic;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.Events;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Dependency")]
    [SerializeField] Transform self;
    [SerializeField] Rigidbody2D body;
    [SerializeField] Hitable hit;

    [Header("Movement")]
    public Vector2 moveValue;
    public Vector2 lastDir;
    [SerializeField] bool moving;

    [Header("Dash")]
    [SerializeField] bool canDash = true;
    public bool CanDash
    {
        get { return canDash; }
        set
        {
            if (!value && canDash)
            {
                Invoke("CD", dashCD);
            }
            canDash = value;
        }
    }
    [SerializeField] ParticleSystem particule;
    public UnityEvent onDash;

    [Header("Parameter")]
    [SerializeField] float speed = 10f;
    [SerializeField] float dashSpeed = 50f;
    [SerializeField] float dashDur = 0.2f;
    [SerializeField] float dashCD = 0.4f;

    public void Movement(InputAction.CallbackContext context)
    {
        moveValue = context.ReadValue<Vector2>();
        if (moveValue.magnitude > 1f)
        {
            moveValue.Normalize();
        }
        if (moveValue.magnitude > 0.1f)
        {
            lastDir = moveValue.normalized;
        }

        moving = moveValue != Vector2.zero;
    }
    public void Dash(InputAction.CallbackContext context)
    {
        if (context.performed && canDash)
        {
            CanDash = false;
            StartCoroutine(Dashing(lastDir, dashDur));
        }
    }

    private void Start()
    {
        particule.Stop();

    }
    public IEnumerator Dashing(Vector2 dir, float dur)
    {
        particule.Play();
        onDash?.Invoke();
        do
        {
            dur -= Time.deltaTime;
            body.velocity += dashSpeed * dir * Time.deltaTime;
            yield return null;
        }
        while (dur > 0);
        yield return new WaitForSecondsRealtime(0.3f);
        particule.Stop();

    }

    public void CD()
    {
        canDash = true;
    }

    void Update()
    {
        if (!moving) return;

        if (Vector2.Dot(moveValue.normalized, body.velocity.normalized) > 0)
        {
            body.velocity += moveValue * speed * Time.deltaTime;
        }
        else
        {
            body.velocity += moveValue * speed * Time.deltaTime;
        }
    }
}

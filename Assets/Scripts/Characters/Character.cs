using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public abstract class Character : MonoBehaviour
{
    [Header("Movement Variables")]
    [SerializeField] protected float speed = 2.0f;
    [SerializeField] protected float direction;
    protected bool facingRight = true;
    //[Header("Jump Variables")]
    //[Header("Attack Variables")]
    //[Header("Character Stats")]

    protected Rigidbody2D rb;
    protected Animator myAnimator;

    public virtual void Start() {
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    public virtual void Update() { }

    public virtual void FixedUpdate() {
        HandleMovement();
    }

    protected void Move()
    {
        rb.velocity = new Vector2(direction*speed,rb.velocity.y);
    }

    protected virtual void HandleMovement()
    {
        Move();
    }

    protected void TurnAround(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight) {
            facingRight = !facingRight;
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        }
    }
}

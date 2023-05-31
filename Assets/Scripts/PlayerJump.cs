using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class PlayerJump : MonoBehaviour
{
    [Header("Public Vars")]
    public float jumpForce;
    public bool grounded;
    private Rigidbody2D rb;

    [Header("Private Vars")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float radOCircle;
    [SerializeField] private LayerMask whatIsGround;

    [Header("Components")]
    private Animator myAnimator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    //myAnimator.SetBool("falling", true);
    //myAnimator.SetBool("falling", false);

    //myAnimator.SetTrigger("jump");
    //myAnimator.ResetTrigger("jump");

    private void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, radOCircle, whatIsGround);

        if (grounded)
        {
            myAnimator.ResetTrigger("jump");
            myAnimator.SetBool("falling", false);
        }

        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            myAnimator.SetTrigger("jump");
        }

        if (rb.velocity.y < 0)
        {
            myAnimator.SetBool("falling", true);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundCheck.position, radOCircle);
    }

    private void FixedUpdate()
    {
        HandleLayers();
    }

    private void HandleLayers()
    {
        if (!grounded)
        {
            myAnimator.SetLayerWeight(1, 1);
        }
        else
        {
            myAnimator.SetLayerWeight(1, 0);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Animator myAnimator;

    private bool facingRight = true;

    public float speed = 2.0f;
    public float horizMovement;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 30f;
    private float dashingTime = 0.3f;
    private float dashingCooldown = 1f;

    [SerializeField] private TrailRenderer tr;


    // Start is called before the first frame update
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(isDashing)
        {
            return;
        }

        horizMovement = Input.GetAxisRaw("Horizontal");

        if(Input.GetKeyDown(KeyCode.LeftShift)&& canDash)
        {
            StartCoroutine(Dash());
        }


    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        /* if (Input.GetKeyDown("left shift"))
         {
             UnityEngine.Debug.Log("mesaj");
             myAnimator.SetTrigger("dash");
        
        } */


        rb2D.velocity = new Vector2(horizMovement*speed,rb2D.velocity.y);
        Flip(horizMovement);
        myAnimator.SetFloat("speed", Mathf.Abs(horizMovement));
      
    }

    private void Flip(float horizontal)
    {
        if (horizontal < 0 && facingRight || horizontal>0 && !facingRight)
        {
            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }


    private IEnumerator Dash()
    {

        canDash = false;
        isDashing = true;
        float originalGravity = rb2D.gravityScale;
        rb2D.gravityScale = 0f;
        rb2D.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb2D.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}

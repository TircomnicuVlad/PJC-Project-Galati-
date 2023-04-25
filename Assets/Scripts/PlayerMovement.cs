using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Animator myAnimator;

    public float speed = 2.0f;
    public float horizMovement;

    // Start is called before the first frame update
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        horizMovement = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        rb2D.velocity = new Vector2(horizMovement*speed,rb2D.velocity.y);

    }
}

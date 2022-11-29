using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public float jumpForce = 200;

    public Transform groundOverlapTopLeft;
    public Transform groundOverlapBottomRight;
    public LayerMask groundLayer;

    private bool grounded = false;

    Rigidbody2D body;
    Animator animator;
    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update() 
    {
    }

    // Fixed Update is called once per fixed interval
    void FixedUpdate()
    {
        animator.SetFloat("velocityX", Abs(body.velocity.x));

        grounded = Physics2D.OverlapArea(groundOverlapTopLeft.position, groundOverlapBottomRight.position, groundLayer);

        if (Input.GetAxis("Vertical") > 0 && grounded) {
            body.AddForce(new Vector2(0f, jumpForce));
        }
        
        Vector3 vel = new Vector3(0, body.velocity.y);
        vel.x = speed * Input.GetAxis("Horizontal");
        sprite.flipX = vel.x < 0;
    
        body.velocity = vel;

        print(body.velocity.x);
    }
}

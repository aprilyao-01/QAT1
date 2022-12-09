using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static System.Math;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public float jumpForce = 200;

    public Transform groundOverlapTopLeft;
    public Transform groundOverlapBottomRight;
    public LayerMask groundLayer;
    public bool flipped = false;
    private bool grounded = false;
    private IInteractable interactable;

    Rigidbody2D body;
    Animator animator;
    SpriteRenderer sprite;

    public void OnInteract()
    {
        if (interactable != null) interactable.Interact(this);
    }

    public void OnJump()
    {
        // print("jump");
        if(grounded)
        {
            body.AddForce(new Vector2(0f, jumpForce));
        }
    }
    
    public void OnMove( InputValue input )
    {
        // print("moving");
        Vector3 vel = new Vector3(0, body.velocity.y);
        vel.x = speed * input.Get<float>();
        sprite.flipX = vel.x < 0;
        body.velocity = vel;
    }

    public void FlipGravity()
    {
        Vector3 s = body.transform.localScale;
        body.transform.localScale = new Vector3(s.x, s.y*-1, s.z);
        
        Vector3 p = transform.position;
        transform.localPosition = new Vector3(p.x, p.y + 1.6f * (flipped ? -1 : 1), p.z);
        body.gravityScale *= -1;
        jumpForce *= -1;
        flipped = !flipped;
    }

    public void SetInteractable( IInteractable i )
    {
        interactable = i;
    }

    public void ClearInteractable() 
    {
        interactable = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponentInChildren<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Fixed Update is called once per fixed interval
    void FixedUpdate()
    {
        animator.SetFloat("velocityX", Abs(body.velocity.x));
        grounded = Physics2D.OverlapArea(groundOverlapTopLeft.position, groundOverlapBottomRight.position, groundLayer);
        // print(grounded);
    }


}


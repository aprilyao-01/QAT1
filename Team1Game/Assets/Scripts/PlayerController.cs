using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using static System.Math;

public class PlayerController : MonoBehaviour
{

    public int health = 3;
    public float speed = 10;
    public float jumpForce = 200;

    public Transform groundOverlapTopLeft;
    public Transform groundOverlapBottomRight;
    public LayerMask groundLayer;
    public GameObject gameOverUI;
    public TextMeshProUGUI gameOverText;
    
    public bool flipped = false;
    private bool grounded = false;
    private IInteractable interactable;

    protected static List<PlayerController> players = new List<PlayerController>();
    Rigidbody2D body;
    Animator animator;
    SpriteRenderer sprite;


    public static void FlipPlayers() {
        players.ForEach( FlipGravity );
    }
    
    public static void FlipGravity(PlayerController p) {
        p.FlipGravity();
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
    
    public void Damage(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            print("ded");
            die();
        }
    }

    public void SetInteractable( IInteractable i )
    {
        interactable = i;
    }

    public void ClearInteractable() 
    {
        interactable = null;
    }

    public void OnInteract()
    {
        if (interactable != null) interactable.Interact();
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

    protected void die()
    {
        Time.timeScale = 0;

        gameOverUI.SetActive(true);
        gameOverText.SetText("Game Over");

        Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponentInChildren<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        players.Add(this);

        if (flipped){
            FlipGravity();
            flipped = true;
        }

    }

    // Fixed Update is called once per fixed interval
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapArea(groundOverlapTopLeft.position, groundOverlapBottomRight.position, groundLayer);
        animator.SetBool("grounded", grounded);
        animator.SetFloat("velocityX", Abs(body.velocity.x));
    }


}


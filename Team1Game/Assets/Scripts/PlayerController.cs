using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;
using static System.Math;
using System;

public class PlayerController : MonoBehaviour
{

    public int health = 3;
    public float speed = 10;
    public float jumpForce = 200;

    public Transform groundOverlapTopLeft;
    public Transform groundOverlapBottomRight;
    public LayerMask groundLayer;
    public Slider healthSlider;
    public GameOverUI gameOverUI;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI gameOverButtonText;
    
    public bool flipped = false;
    private bool grounded = false;
    private IInteractable interactable;

    protected static List<PlayerController> players = new List<PlayerController>();
    Rigidbody2D body;
    Animator animator;
    SpriteRenderer sprite;
    public Action PlayerDie;



    public static void FlipPlayers()
    {
        players.ForEach( FlipGravity );
    }
    
    public static void FlipGravity(PlayerController p)
    {
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
        healthSlider.value = health;
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
        PlayerDie?.Invoke();
        gameOverUI.gameObject.SetActive(true);
        gameOverUI.failed = true;
        gameOverText.SetText("Game Over");
        gameOverButtonText.SetText("Try Again");

        Time.timeScale = 0;
        this.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponentInChildren<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        players.Add(this);

        if (flipped)
        {
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



    // new add testable
    public void setInteractable(IInteractable isInteract)
    {
        interactable = isInteract;
    }

    public IInteractable GetInteractable()
    {
        return interactable;
    }


}

//public class PlayerController
//{
//    private int health = 3;
//    private float speed = 10;
//    private float jumpForce = 200;

//    private IInteractable interactable;
//    private bool flipped = false;
//    private bool grounded = false;

//    private IPlayerMovement playerMovement;
//    private IPlayerGravity playerGravity;
//    private IPlayerInput playerInput;
//    private IPlayerAnimations playerAnimations;
//    private IPlayerHealth playerHealth;

//    public PlayerController(IPlayerMovement playerMovement, IPlayerGravity playerGravity, IPlayerInput playerInput, IPlayerAnimations playerAnimations, IPlayerHealth playerHealth)
//    {
//        this.playerMovement = playerMovement;
//        this.playerGravity = playerGravity;
//        this.playerInput = playerInput;
//        this.playerAnimations = playerAnimations;
//        this.playerHealth = playerHealth;
//    }

//    public void Update()
//    {
//        playerMovement.Move();
//        playerGravity.CheckGround();
//        playerAnimations.Animate();
//        playerHealth.CheckHealth();
//    }

//    public void OnJump()
//    {
//        playerMovement.Jump();
//    }

//    public void OnMove(InputValue input)
//    {
//        playerMovement.Move(input);
//    }

//    public void OnInteract()
//    {
//        playerInput.Interact();
//    }

//    public void Damage(int dmg)
//    {
//        playerHealth.Damage(dmg);
//    }

//    public void SetInteractable(IInteractable i)
//    {
//        playerInput.SetInteractable(i);
//    }

//    public void ClearInteractable()
//    {
//        playerInput.ClearInteractable();
//    }

//    public void FlipGravity()
//    {
//        playerGravity.Flip();
//    }

//    public static void FlipPlayers()
//    {
//        players.ForEach(FlipGravity);
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;
using static System.Math;

/// <summary>
/// Class <c>PlayerController</c>, derives from <c>MonoBehaviour</c>.
/// Handles all player actions.
/// </summary>
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

    ///<summary>
    /// Static Method <c>FlipPlayers</c> flips gravity for all players
    ///</summary>
    public static void FlipPlayers()
    {
        players.ForEach( FlipGravity );
    }
    
    ///<summary>
    /// Static Method <c>FlipPlayers</c> flips gravity for specified player.
    /// Parameter <param>p</param> PlayerController component for player
    /// who's gravity to flip.
    ///</summary>
    public static void FlipGravity(PlayerController p)
    {
        p.FlipGravity();
    }
    
    ///<summary>
    /// Method <c>FlipGravity</c> flips gravity for player.
    ///</summary>
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
    
    ///<summary>
    /// Method <c>Damage</c> deals <param>dmg</param> damage to player.
    ///</summary>
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

    ///<summary>
    /// Method <c>SetInteractable</c> sets current <c>IInteractable</c>
    /// <param>i</param> with which player can interact with,
    /// upon pressing the interact key
    /// </summary>
    public void SetInteractable( IInteractable i )
    {
        interactable = i;
    }

    ///<summary>
    /// Method <c>ClearInteractable</c> clears current <c>IInteractable</c>
    /// with which player can interact with, ensuring that pressing the 
    /// interact key does nothing.
    ///</summary>
    public void ClearInteractable() 
    {
        interactable = null;
    }

    ///<summary>
    /// Method <c>OnInteract</c> called on press of interact button.
    /// calls <c>IInteractable.Interact()</c> on currently accessible
    /// <c>IInteractable</c>
    ///</summary>
    public void OnInteract()
    {
        if (interactable != null) interactable.Interact();
    }

    ///<summary>
    /// Method <c>OnJump</c> called on press of jump button.
    /// Applies positive y velocity, if player is grounded.
    ///</summary>
    public void OnJump()
    {
        // print("jump");
        if(grounded)
        {
            body.AddForce(new Vector2(0f, jumpForce));
        }
    }
    
    /// <summary>
    /// Method <c>OnMove</c> called on press of a directional key.
    /// Parameter <param>input</param> is a float passed from the
    /// input controller, specifying movement axis value.
    /// Makes player move left and right.
    /// </summary>
    public void OnMove( InputValue input )
    {
        // print("moving");
        Vector3 vel = new Vector3(0, body.velocity.y);
        vel.x = speed * input.Get<float>();
        sprite.flipX = vel.x < 0;
        body.velocity = vel;
    }

    /// <summary>
    /// Method <c>die</c> called when player health reaches 0.
    /// Destroys player object, pauses game and displays game over
    /// menu
    /// </summary>
    protected void die()
    {
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
        // check overlap area at players feet to see if grounded
        grounded = Physics2D.OverlapArea(groundOverlapTopLeft.position, groundOverlapBottomRight.position, groundLayer);
        
        // set animator parameters
        animator.SetBool("grounded", grounded);
        animator.SetFloat("velocityX", Abs(body.velocity.x));
    }


}


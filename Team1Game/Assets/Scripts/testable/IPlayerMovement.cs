using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IPlayerMovement
{
    void Move();
    void Jump();
    void Move(InputValue input);
}

public class PlayerMovement : IPlayerMovement
{
    private Rigidbody2D body;
    private SpriteRenderer sprite;
    private float speed;

    public PlayerMovement(Rigidbody2D body, SpriteRenderer sprite, float speed)
    {
        this.body = body;
        this.sprite = sprite;
        this.speed = speed;
    }

    public void Move()
    {
        // Move logic goes here
    }

    public void Jump()
    {
        // Jump logic goes here
    }

    public void Move(InputValue input)
    {
        // Move logic with input goes here
    }
}


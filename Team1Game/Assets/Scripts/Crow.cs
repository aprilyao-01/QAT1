using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crow : ContactDamage
{
    public Transform overlapFront;
    public float speed = 10;

    Rigidbody2D body;

    private CrowMovement crowMovement;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        crowMovement = new CrowMovement(overlapFront, speed, body);
        crowMovement.Initialise(speed);
    }

    void Update()
    {
        crowMovement.Move();

    }
}
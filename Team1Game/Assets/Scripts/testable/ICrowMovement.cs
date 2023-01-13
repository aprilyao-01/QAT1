using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICrowMovement
{
    void Initialise(float speed);
    void Move(bool intest);
}


public class CrowMovement: ICrowMovement
{
    private Transform overlapFront;
    public float speed;
    public Rigidbody2D body;

    public CrowMovement(Transform overlapFront, float speed, Rigidbody2D body)
    {
        this.overlapFront = overlapFront;
        this.speed = speed;
        this.body = body;
    }

    public void Initialise(float speed)
    {
        Vector3 vel = new Vector3();
        vel.x -= speed;
        body.velocity = vel;
    }

    public void Move(bool intest = false)
    {
        bool frontCollision = intest;

        if (!intest)
        {
            frontCollision = Physics2D.OverlapPoint(overlapFront.position);
        }
        Debug.Log(frontCollision);
        if (frontCollision)
        {
            Vector3 s = body.transform.localScale;
            Vector3 vel = body.velocity;


            s.x *= -1;
            vel.x *= -1;

            body.transform.localScale = s;
            body.velocity = vel;
            Debug.Log(body.transform.localScale);
        }
    }
}
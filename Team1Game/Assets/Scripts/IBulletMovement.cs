using System.Collections;
using System.Collections.Generic;
using Codice.CM.Common;
using UnityEngine;

public interface IBulletMovement
{
    void Initialize(Transform transform, float speed);
    bool Move();
}

public class BulletMovement : IBulletMovement
{
    public float speed;
    private Rigidbody2D body;
    public Transform overlapFront;

    public BulletMovement(Transform transform, float initialSpeed, Rigidbody2D rigidbody)
    {
        overlapFront = transform;
        speed = initialSpeed;
        body = rigidbody;
    }

    public void Initialize(Transform transform, float initialSpeed)
    {
        overlapFront = transform;
        speed = initialSpeed;
        //body = GetComponent<Rigidbody2D>();
    }

    public bool Move()
    {
        Vector3 vel = new Vector3();
        vel.x += speed;
        body.velocity = vel;
        bool frontCollision = Physics2D.OverlapPoint(overlapFront.position);

        return frontCollision;
    }
}

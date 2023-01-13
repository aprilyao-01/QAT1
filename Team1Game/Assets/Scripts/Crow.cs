using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crow : ContactDamage
{

    public Transform overlapFront;
    public float speed = 10;

    Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        Vector3 vel = new Vector3();
        vel.x -= speed;
        body.velocity = vel;
    }

    // Update is called once per frame
    void Update()
    {
        bool frontCollision = Physics2D.OverlapPoint(overlapFront.position);

        if(frontCollision)
        {
            Vector3 s = transform.localScale;
            Vector3 vel = body.velocity;
            
            s.x *= -1;
            vel.x *= -1;

            transform.localScale = s;
            body.velocity = vel;
        }
    }
}

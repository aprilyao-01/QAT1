using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform overlapFront;
    public float speed = 10;
    Rigidbody2D body;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        Vector3 vel = new Vector3();
        vel.x += speed;
        body.velocity = vel;
    }

    // Update is called once per frame
    void Update()
    {
        bool frontCollision = Physics2D.OverlapPoint(overlapFront.position);

        if(frontCollision)
        {
            Destroy(this.gameObject);
        }
    }
}

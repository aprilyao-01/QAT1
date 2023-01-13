using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// Class <c>Bullet</c> derives from <c>MonoBehaviour</c>.
/// Handles behaviour for bullet enemy / prefab
///</summary>
public class Bullet : MonoBehaviour
{
    public Transform overlapFront;
    public float speed = 10;
    public bool faceLeft = false;
    public LayerMask groundLayer;
    Rigidbody2D body;


    // Start is called before the first frame update
    void Start()
    {
        // Move left if facing left
        if(faceLeft) speed *= -1;

        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // assign constant velocity
        Vector3 vel = new Vector3();
        vel.x += speed;
        body.velocity = vel;
        
        // check frontal collisions
        bool frontCollision = Physics2D.OverlapPoint(overlapFront.position);

        // if collided, destroy the bullet
        if(frontCollision) Destroy(this.gameObject);
    }
}

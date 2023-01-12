using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class Bullet : MonoBehaviour
//{
//    public Transform overlapFront;
//    public float speed = 10;
//    public bool faceLeft = false;
//    public LayerMask groundLayer;
//    Rigidbody2D body;


//    // Start is called before the first frame update
//    void Start()
//    {
//        if (faceLeft) speed *= -1;

//        body = GetComponent<Rigidbody2D>();


//        print("Bullet");
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        Vector3 vel = new Vector3();
//        vel.x += speed;
//        body.velocity = vel;
//        bool frontCollision = Physics2D.OverlapPoint(overlapFront.position);

//        if (frontCollision)
//        {
//            Destroy(this.gameObject);
//        }
//    }

//}


public class Bullet : MonoBehaviour
{
    private IBulletMovement _bulletMovement;

    public Transform overlapFront;
    public float speed = 10;
    public bool faceLeft = false;
    public LayerMask groundLayer;
    Rigidbody2D body;

    public Bullet(IBulletMovement bulletMovement)
    {
        _bulletMovement = bulletMovement;
    }

    void Start()
    {
        if (faceLeft) speed *= -1;

        body = GetComponent<Rigidbody2D>();

        print("Bullet");

        _bulletMovement = new BulletMovement(overlapFront, speed, body);
    }

    // Update is called once per frame
    void Update()
    {
        bool frontCollision = _bulletMovement.Move();
        if (frontCollision)
        {
            Destroy(this.gameObject);
        }
    }
}


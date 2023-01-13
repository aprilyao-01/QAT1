using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// Class <c>Bullet</c> derives from <c>MonoBehaviour</c>.
/// Handles behaviour for bullet enemy / prefab
///</summary>
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


        if (faceLeft) speed *= -1;  // Move left if facing left

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


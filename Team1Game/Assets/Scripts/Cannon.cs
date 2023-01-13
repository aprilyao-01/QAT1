using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{

    public Bullet projectile;
    public float fireInterval = 0.1f;
    public bool faceLeft = false;

    protected float timeRemaining;

    public void fire()
    {
        var bullet = Instantiate(projectile, transform);
        bullet.GetComponent<Bullet>().faceLeft = faceLeft;
        Physics2D.IgnoreCollision(GetComponentInChildren<Collider2D>(), bullet.GetComponents<Collider2D>()[1]);
        
        timeRemaining = fireInterval;
    }

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = fireInterval;
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;
        if(timeRemaining <= 0) fire();
    }

}

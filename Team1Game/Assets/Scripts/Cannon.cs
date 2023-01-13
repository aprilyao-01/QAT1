using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>Cannon</c> derives from <c>MonoBehaviour</c>.
/// Handles behaviour of Cannon enemy / prefab.
/// </summary>
public class Cannon : MonoBehaviour
{

    public GameObject projectile;
    public float fireInterval = 0.1f;
    public bool faceLeft = false;

    protected float timeRemaining;

    /// <summary>
    /// Method <c>Fire</c> called after every fire interval.
    /// Instantiates a Bullet prefab.
    /// </summary>
    public void Fire()
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
        if(timeRemaining <= 0) Fire();
    }

}

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BulletTest
{

    //Rigidbody2D body;
    //Bullet bullet;


    //[SetUp]         // @BeforeEach
    //public void SetUp()
    //{
    //    Debug.Log("SetUp");
    //    //bullet = new Bullet();
    //    //playerController = player.AddComponent<PlayerController>();
    //    //body = bullet.AddComponent<Rigidbody2D>();

    //}


    //[TearDown]      // @AfterEach
    //public void Teardown()
    //{
    //    var objects = GameObject.FindObjectsOfType<GameObject>();
    //    foreach (var obj in objects)
    //    {
    //        if (obj.name.Contains("Test"))
    //            GameObject.Destroy(obj);
    //    }
    //    Debug.Log("TearDown");
    //}



    private BulletMovement bulletMovement;
    private Transform bulletTransform;
    private float speed = 10f;
    private Rigidbody2D bulletRigidbody;

    [SetUp]
    public void SetUp()
    {
        bulletTransform = new GameObject().transform;
        bulletRigidbody = new GameObject().AddComponent<Rigidbody2D>();
        bulletMovement = new BulletMovement(bulletTransform, speed, bulletRigidbody);
    }

    [TearDown]
    public void TearDown()
    {
        //GameObject.Destroy(bulletTransform.gameObject);
        //GameObject.Destroy(bulletRigidbody.gameObject);
        GameObject.DestroyImmediate(bulletTransform.gameObject);
        GameObject.DestroyImmediate(bulletRigidbody.gameObject);
    }

    [Test]
    public void Initialize_SetsTransformAndSpeed()
    {
        //Arrange
        Transform newTransform = new GameObject().transform;
        float newSpeed = 20f;

        //Act
        bulletMovement.Initialize(newTransform, newSpeed);

        //Assert
        Assert.AreEqual(newTransform, bulletMovement.overlapFront);
        Assert.AreEqual(newSpeed, bulletMovement.speed);
    }

    [Test]
    public void Move_SetsVelocityAndChecksCollision()
    {
        //Act
        bool frontCollision = bulletMovement.Move();

        //Assert
        Assert.AreEqual(new Vector3(speed, 0, 0), bulletRigidbody.velocity);
        Assert.AreEqual(false, frontCollision);
    }

}
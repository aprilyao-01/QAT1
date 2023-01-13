using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BulletMovementTests
{

    private BulletMovement bulletMovement;
    private Transform bulletTransform;
    private float speed = 10f;
    private Rigidbody2D bulletRigidbody;

    [SetUp]     // @BeforeEach
    public void SetUp()
    {
        //Debug.Log("SetUp");
        bulletTransform = new GameObject().transform;
        bulletRigidbody = new GameObject().AddComponent<Rigidbody2D>();
        bulletMovement = new BulletMovement(bulletTransform, speed, bulletRigidbody);
    }

    [TearDown]      // @AfterEach
    public void TearDown()
    {
        GameObject.DestroyImmediate(bulletTransform.gameObject);
        GameObject.DestroyImmediate(bulletRigidbody.gameObject);
        //Debug.Log("TearDown");
    }

    [Test]
    public void TestInitialise_SetsTransformAndSpeed()
    {
        Transform newTransform = new GameObject().transform;        // arrange
        float newSpeed = 20f;

        bulletMovement.Initialise(newTransform, newSpeed);      // act

        Assert.AreEqual(newTransform, bulletMovement.overlapFront); // assert
        Assert.AreEqual(newSpeed, bulletMovement.speed);
    }

    [Test]
    public void TestMove_SetsVelocityAndChecksCollision()
    {
        var expectVelocity = new Vector2(speed, 0);     // arrange
        bool frontCollision = bulletMovement.Move();    // act
        Assert.AreEqual(expectVelocity, bulletRigidbody.velocity);    // assert
        Assert.AreEqual(false, frontCollision);
    }

    [Test]
    public void TestInitialise_NullTransform()
    {
        Transform nullTransform = null;     // arrange

        // act and assert
        Assert.Throws<System.ArgumentNullException>(() => bulletMovement.Initialise(nullTransform, speed));
    }

    [Test]
    public void TestMove_NoRigidbody()
    {
        bulletMovement.body = null;     // arrange

        // act and assert
        Assert.Throws<System.NullReferenceException>(() => bulletMovement.Move());
    }

    [Test]
    public void TestMove_VelocityIsCorrect()
    {
        bulletMovement.Initialise(bulletTransform, 10f);        // arrange
        bulletMovement.Move();      // act
        Assert.AreEqual(new Vector2(10, 0), bulletRigidbody.velocity);  // assert
    }

    [Test]
    public void TestMove_SpeedChange()
    {
        bulletMovement.Initialise(bulletTransform, 10f);    // arrange
        bulletMovement.speed = 20f;

        bulletMovement.Move();      // act
        Assert.AreEqual(new Vector2(20, 0), bulletRigidbody.velocity);  // assert
    }
}
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CrowMovementTests
{
    private CrowMovement crowMovement;
    private Transform overlapFront;
    private Rigidbody2D body;

    [SetUp]
    public void SetUp()
    {
        //Debug.Log("SetUp");
        overlapFront = new GameObject().transform;
        body = new GameObject().AddComponent<Rigidbody2D>();
        crowMovement = new CrowMovement(overlapFront, 10, body);
    }

    [TearDown]
    public void TearDown()
    {
        GameObject.DestroyImmediate(overlapFront.gameObject);
        GameObject.DestroyImmediate(body.gameObject);
        //Debug.Log("TearDown");
    }

    [Test]
    public void TestInitialise()
    {
        crowMovement.Initialise(10);    // act
        Assert.AreEqual(new Vector2(-10, 0), body.velocity);        // assert
    }

    [Test]
    public void TestMove_Normal()
    {
        var scaleBefore = body.transform.localScale;        // arrange
        var velocityBefore = body.velocity;

        crowMovement.Move();        // act

        Assert.AreEqual(scaleBefore, body.transform.localScale);    // assert
        Assert.AreEqual(velocityBefore, body.velocity);
    }

    [Test]
    public void TestMove_FrontCollisionTrue()
    {
        var velocityBefore = body.velocity;     // arrange
        crowMovement.Move(true);    // act
        Assert.AreEqual(velocityBefore.x * -1, body.velocity.x); // assert
    }

    [Test]
    public void TestMove_VelocityChanged()
    {
        var scaleBefore = body.transform.localScale;    // arrange
        scaleBefore.x *= -1;
        var scaleExpect = scaleBefore;
        body.velocity = new Vector3(5, 0);

        crowMovement.Move(true);        // act

        Assert.AreEqual(scaleExpect, body.transform.localScale);        // assert
        Assert.AreEqual(-5, body.velocity.x);
    }

    [Test]
    public void TestMove_ScaleChanged()
    {
        var velocityBefore = body.velocity;     // arrange

        body.transform.localScale = new Vector3(2, 1, 1);   // act
        crowMovement.Move();

        Assert.AreEqual(velocityBefore, body.velocity);     // asssert
        Assert.AreEqual(2, body.transform.localScale.x);
    }

}

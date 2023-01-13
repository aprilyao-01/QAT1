using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System;
using System.Reflection;

public class PlayerControllerTest
{

    PlayerController player;
    GravitySwitch gravitySwitch;
    Rigidbody2D body;
    Transform transform;
    Animator animator;
    bool grounded;

    [SetUp]         // @BeforeEach
    public void SetUp()
    {
        Debug.Log("SetUp");
        player = new GameObject().AddComponent<PlayerController>();
        player.flipped = false;

        //player = new GameObject();
        //playerController = player.AddComponent<PlayerController>();
        body = player.GetComponentInChildren<Rigidbody2D>();
        animator = player.GetComponentInChildren<Animator>();
        //transform = playerController.transform;
        grounded = false;
    }


    [TearDown]      // @AfterEach
    public void Teardown()
    {
        GameObject.DestroyImmediate(player.gameObject);
        Debug.Log("TearDown");
    }



    [Test]
    public void TestFlipGravity()
    {
        Vector3 initialScale = body.transform.localScale;
        Vector3 initialPosition = player.transform.position;
        float initialGravityScale = body.gravityScale;
        float initialJumpForce = player.jumpForce;

        player.FlipGravity();

        Vector3 newScale = body.transform.localScale;
        Vector3 newPosition = player.transform.position;
        float newGravityScale = body.gravityScale;
        float newJumpForce = player.jumpForce;

        Assert.AreNotEqual(initialScale, newScale);
        Assert.AreNotEqual(initialPosition, newPosition);
        Assert.AreNotEqual(initialGravityScale, newGravityScale);
        Assert.AreNotEqual(initialJumpForce, newJumpForce);
        Assert.IsTrue(player.flipped);
    }


    [Test]
    public void TestFlipGravity_ShouldFlippedFlag()
    {
        Debug.Log("now test");
        player.flipped = false;   // arrange
        player.FlipGravity();     // act
        Assert.IsTrue(player.flipped);    // assert
    }

    [Test]
    public void TestFlipGravity_ShouldChangedPosition()
    {
        Debug.Log("now test");
        transform.position = new Vector3(1, 2, 3);  // arrange
        //float gravityScaleBefore = player.transform.localScale.y;
        player.FlipGravity();     // act
        Assert.AreEqual(player.transform.position, new Vector3(1, 0.4f, 3));    // assert

    }

    [Test]
    public void TestFlipGravity_ShouldGravityScale()
    {
        Debug.Log("now test");
        body.gravityScale = 1;      //arrange
        gravitySwitch.Interact();   // act
        Assert.AreEqual(body.gravityScale, -1); // assert
    }

    [Test]
    public void OnJump_AddsJumpForceToYVelocity()
    {
        grounded = true;        // arrange
        var initialVelocityY = body.velocity.y;
        player.OnJump();      // act
        Assert.AreNotEqual(initialVelocityY, body.velocity.y);      // assert
        Assert.AreEqual(player.jumpForce, body.velocity.y);
    }


    [Test]
    public void TestDamage()
    {
        var playerController = new GameObject().AddComponent<PlayerController>();

        playerController.health = 3;
        int dieCalledCount = 0;
        playerController.PlayerDie += delegate () { dieCalledCount++; };
        playerController.Damage(2);


        // check that the player's health has been reduced
        Assert.AreEqual(1, playerController.health);

        playerController.Damage(1);
        // check that the player's health has been reduced
        Assert.AreEqual(0, playerController.health);

        // check that the die method has been called
        Assert.AreEqual(1, dieCalledCount);
    }

    [Test]
    public void OnMove_SetsVelocityX()
    {
        //var inputValue = new InputValue(1f);        // arrange
        //playerController.OnMove(inputValue);        //act
        //Assert.AreEqual(playerController.speed, body.velocity.x);       //assert
    }
}

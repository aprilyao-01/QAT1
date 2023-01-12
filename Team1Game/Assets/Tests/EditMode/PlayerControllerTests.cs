using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.InputSystem;
using System;
using System.Reflection;

public class PlayerControllerTest
{

    GameObject player;
    PlayerController playerController;
    GravitySwitch gravitySwitch;
    Rigidbody2D body;
    Transform transform;
    Animator animator;
    bool grounded;

    [SetUp]         // @BeforeEach
    public void SetUp()
    {
        Debug.Log("SetUp");
        player = new GameObject();
        playerController = player.AddComponent<PlayerController>();
        body = player.AddComponent<Rigidbody2D>();
        animator = player.AddComponent<Animator>();
        transform = playerController.transform;
        grounded = false;
    }


    [TearDown]      // @AfterEach
    public void Teardown()
    {
        var objects = GameObject.FindObjectsOfType<GameObject>();
        foreach (var obj in objects)
        {
            if (obj.name.Contains("Test"))
                GameObject.Destroy(obj);
        }
        Debug.Log("TearDown");
    }


    [Test]
    public void TestFlipGravity_ShouldFlippedFlag()
    {
        Debug.Log("now test");
        playerController.flipped = false;   // arrange
        playerController.FlipGravity();     // act
        Assert.IsTrue(playerController.flipped);    // assert
    }

    [Test]
    public void TestFlipGravity_ShouldChangedPosition()
    {
        Debug.Log("now test");
        transform.position = new Vector3(1, 2, 3);  // arrange
        //float gravityScaleBefore = player.transform.localScale.y;
        playerController.FlipGravity();     // act
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
        playerController.OnJump();      // act
        Assert.AreNotEqual(initialVelocityY, body.velocity.y);      // assert
        Assert.AreEqual(playerController.jumpForce, body.velocity.y);
    }


    [Test]
    public void OnMove_SetsVelocityX()
    {
        //var inputValue = new InputValue(1f);        // arrange
        //playerController.OnMove(inputValue);        //act
        //Assert.AreEqual(playerController.speed, body.velocity.x);       //assert
    }
}

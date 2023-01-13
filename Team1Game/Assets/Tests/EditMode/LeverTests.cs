using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;
using static UnityEditor.Experimental.GraphView.GraphView;

public class LeverTests
{
    private Lever lever;
    private Door[] doors;
    private SpriteRenderer sprite;
    private PlayerController player;

    [SetUp]
    public void SetUp()
    {
        // Create objects for the test
        GameObject leverObject = new GameObject();
        leverObject.AddComponent<SpriteRenderer>();
        lever = leverObject.AddComponent<Lever>();

        for (int i = 0; i < 2; i++)
        {
            doors[i] = new GameObject().AddComponent<Door>();
        }
        doors[0] = leverObject.AddComponent<Door>();
        doors[1] = leverObject.AddComponent<Door>();
        player = new GameObject().AddComponent<PlayerController>();

        // Add the doors to the lever's doors array
        lever.doors = doors;
        lever.SetSprite(sprite);
    }

    [TearDown]
    public void TearDown()
    {
        sprite = null;
        GameObject.DestroyImmediate(player.gameObject);
        GameObject.DestroyImmediate(lever.gameObject);
        GameObject.DestroyImmediate(doors[0].gameObject);
        GameObject.DestroyImmediate(doors[1].gameObject);
    }

    [Test]
    public void Interact_TogglesDoors()
    {
        doors[0].open = false;      // arrange
        doors[1].open = false;

        // Act
        lever.Interact();

        // Assert
        Assert.AreEqual(true, doors[0].open);
        Assert.AreEqual(true, doors[1].open);
    }

    [Test]
    public void Interact_FlipsSprite()
    {
        // Arrange
        sprite.flipX = false;

        // Act
        lever.Interact();

        // Assert
        Assert.AreEqual(true, sprite.flipX);
    }

    [Test]
    public void Enter_SetsInteractable()
    {
        // Arrange
        Collider2D col = new Collider2D();
        col.tag = "Player";

        // Act
        lever.Enter(col);

        // Assert
        Assert.AreEqual(lever, player.GetInteractable());
    }

    [Test]
    public void Exit_ClearsInteractable()
    {
        // Arrange
        Collider2D col = new Collider2D();
        col.tag = "Player";
        player.setInteractable(lever);

        // Act
        lever.Exit(col);

        // Assert
        Assert.AreEqual(null, player.GetInteractable());
    }

}

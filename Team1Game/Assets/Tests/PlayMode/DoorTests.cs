using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DoorTests
{
    [UnityTest]
    public IEnumerator TestToggle_OpenToClosed()
    {
        // Create new door game object
        var door = new GameObject().AddComponent<Door>();

        // Assign open and closed sprites
        door.openSprite = Resources.Load<Sprite>("OpenSprite");
        door.closedSprite = Resources.Load<Sprite>("ClosedSprite");

        // Set door to open
        door.open = true;

        // Wait for a frame to ensure door is set up correctly
        yield return null;

        // Toggle door
        door.Toggle();

        // Wait for a frame to ensure door is updated correctly
        yield return null;

        // Check that door is now closed
        Assert.IsFalse(door.open);

        // Check that sprite is set to closed sprite
        var spriteRenderer = door.GetComponent<SpriteRenderer>();
        Assert.AreEqual(door.closedSprite, spriteRenderer.sprite);

        // Check that collider is now enabled
        var collider = door.GetComponent<Collider2D>();
        Assert.IsTrue(collider.enabled);

        // Clean up door game object
        UnityEngine.Object.Destroy(door.gameObject);
    }

    [UnityTest]
    public IEnumerator TestToggle_ClosedToOpen()
    {
        // Create new door game object
        var door = new GameObject().AddComponent<Door>();

        // Assign open and closed sprites
        door.openSprite = Resources.Load<Sprite>("OpenSprite");
        door.closedSprite = Resources.Load<Sprite>("ClosedSprite");

        // Set door to closed
        door.open = false;

        // Wait for a frame to ensure door is set up correctly
        yield return null;

        // Toggle door
        door.Toggle();

        // Wait for a frame to ensure door is updated correctly
        yield return null;

        // Check that door is now open
        Assert.IsTrue(door.open);

        // Check that sprite is set to open sprite
        var spriteRenderer = door.GetComponent<SpriteRenderer>();
        Assert.AreEqual(door.openSprite, spriteRenderer.sprite);

        // Check that collider is now disabled
        var collider = door.GetComponent<Collider2D>();
        Assert.IsFalse(collider.enabled);

        // Clean up door game object
        UnityEngine.Object.Destroy(door.gameObject);
    }

}

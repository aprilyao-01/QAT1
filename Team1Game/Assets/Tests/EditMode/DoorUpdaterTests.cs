using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DoorUpdaterTests
{
    private Door door;
    private DoorUpdater updater;
    private Sprite openSprite;
    private Sprite closedSprite;
    public bool open = false;


    [SetUp]
    public void SetUp()
    {
        door = new Door();
        updater = new DoorUpdater(open);
    }

    [TearDown]
    public void TearDown()
    {
        openSprite = null;
        closedSprite = null;
        UnityEngine.Object.DestroyImmediate(updater.gameObject);
    }


    [Test]
    public void TestUpdateDoor_Open()
    {
        var spriteRenderer = door.GetComponent<SpriteRenderer>();       // arrange
        var collider = door.GetComponent<Collider2D>();

        updater.UpdateDoor(true);       // act
       
        Assert.AreEqual(spriteRenderer.sprite, openSprite);     // assert
        Assert.IsFalse(collider.enabled);
    }

    [Test]
    public void TestUpdateDoor_Closed()
    {
        var spriteRenderer = door.GetComponent<SpriteRenderer>();       // arrange
        var collider = door.GetComponent<Collider2D>();

        updater.UpdateDoor(false);      // act
        
        Assert.AreEqual(spriteRenderer.sprite, closedSprite);       // assert
        Assert.IsTrue(collider.enabled);
    }
}


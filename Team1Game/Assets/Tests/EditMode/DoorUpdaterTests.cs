using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DoorUpdaterTests
{
    //private Door door;
    private DoorUpdater updater;
    private Sprite openSprite;
    private Sprite closedSprite;
    private GameObject doorGameObject;
    public bool open = false;


    [SetUp]
    public void SetUp()
    {
        doorGameObject = new GameObject();
        updater = new DoorUpdater(doorGameObject, open);
    }

    [TearDown]
    public void TearDown()
    {
        openSprite = null;
        closedSprite = null;
        UnityEngine.Object.DestroyImmediate(doorGameObject);
    }


    [Test]
    public void TestUpdateDoor_Open()
    {
        var spriteRenderer = doorGameObject.GetComponent<SpriteRenderer>();       // arrange
        var collider = doorGameObject.GetComponent<Collider2D>();

        updater.UpdateDoor(true);       // act
       
        Assert.AreEqual(spriteRenderer.sprite, openSprite);     // assert
        Assert.IsFalse(collider.enabled);
    }

    [Test]
    public void TestUpdateDoor_Closed()
    {
        var spriteRenderer = doorGameObject.GetComponent<SpriteRenderer>();       // arrange
        var collider = doorGameObject.GetComponent<Collider2D>();

        updater.UpdateDoor(false);      // act
        
        Assert.AreEqual(spriteRenderer.sprite, closedSprite);       // assert
        Assert.IsTrue(collider.enabled);
    }
}


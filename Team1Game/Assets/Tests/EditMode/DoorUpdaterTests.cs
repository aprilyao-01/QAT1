using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DoorUpdaterTests
{
<<<<<<< HEAD
<<<<<<< HEAD
=======
    //private Door door;
>>>>>>> 68171e5 (Fix merge conflicts)
=======
>>>>>>> 93ead64 (Fix merge conflicts)
    private DoorUpdater updater;
    private Sprite openSprite;
    private Sprite closedSprite;
    private GameObject doorGameObject;
<<<<<<< HEAD
<<<<<<< HEAD

=======
>>>>>>> 68171e5 (Fix merge conflicts)
=======

>>>>>>> 93ead64 (Fix merge conflicts)
    public bool open = false;


    [SetUp]
    public void SetUp()
    {
        doorGameObject = new GameObject();
<<<<<<< HEAD
<<<<<<< HEAD
        doorGameObject.AddComponent<SpriteRenderer>();
        doorGameObject.AddComponent<BoxCollider2D>();
=======
>>>>>>> 68171e5 (Fix merge conflicts)
=======
        doorGameObject.AddComponent<SpriteRenderer>();
        doorGameObject.AddComponent<BoxCollider2D>();

>>>>>>> 93ead64 (Fix merge conflicts)
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
<<<<<<< HEAD
<<<<<<< HEAD
=======
        var collider = doorGameObject.GetComponent<Collider2D>();
>>>>>>> 68171e5 (Fix merge conflicts)
=======
>>>>>>> 93ead64 (Fix merge conflicts)

        updater.UpdateDoor(true);       // act
       
        Assert.AreEqual(spriteRenderer.sprite, openSprite);     // assert
        Assert.IsFalse(doorGameObject.GetComponent<BoxCollider2D>().enabled);
<<<<<<< HEAD

=======
>>>>>>> 93ead64 (Fix merge conflicts)
    }

    [Test]
    public void TestUpdateDoor_Closed()
    {
        var spriteRenderer = doorGameObject.GetComponent<SpriteRenderer>();       // arrange
<<<<<<< HEAD
<<<<<<< HEAD

=======
        var collider = doorGameObject.GetComponent<Collider2D>();
>>>>>>> 68171e5 (Fix merge conflicts)
=======
>>>>>>> 93ead64 (Fix merge conflicts)

        updater.UpdateDoor(false);      // act
        
        Assert.AreEqual(spriteRenderer.sprite, closedSprite);       // assert
        Assert.IsFalse(doorGameObject.GetComponent<BoxCollider2D>().enabled);
<<<<<<< HEAD

=======
>>>>>>> 93ead64 (Fix merge conflicts)
    }
}


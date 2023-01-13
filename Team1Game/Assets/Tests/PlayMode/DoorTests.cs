using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DoorTests
{
    //private Door door;


    //[UnitySetUp]
    //public void SetUp()
    //{
    //    door = new GameObject().AddComponent<Door>();

    //    door.gameObject.AddComponent<SpriteRenderer>();      // add components to door
    //    door.gameObject.AddComponent<BoxCollider2D>();

    //    door.openSprite = Resources.Load<Sprite>("OpenSprite");     // assign sprites
    //    door.closedSprite = Resources.Load<Sprite>("ClosedSprite");
    //}


    //[UnityTearDown]
    //public void TearDown()
    //{
    //    UnityEngine.Object.Destroy(door.gameObject);        // clean up door game object
    //}



    [UnityTest]
    public IEnumerator TestToggle_OpenToClosed()
    {
        var door = new GameObject().AddComponent<Door>();

        door.gameObject.AddComponent<SpriteRenderer>();
        door.gameObject.AddComponent<BoxCollider2D>();

        door.openSprite = Resources.Load<Sprite>("OpenSprite");
        door.closedSprite = Resources.Load<Sprite>("ClosedSprite");

        door.open = true;
        yield return null;              // wait for a frame

        door.Toggle();
        yield return null;      // wait for a frame

        Assert.IsFalse(door.open);              // check that door is now closed

        var spriteRenderer = door.GetComponent<SpriteRenderer>();           // check that sprite is set to closed sprite
        Assert.AreEqual(door.closedSprite, spriteRenderer.sprite);

        var collider = door.GetComponent<BoxCollider2D>();        // check that collider is now enabled
        Assert.IsTrue(collider.enabled);

        UnityEngine.Object.Destroy(door.gameObject);        // clean up door game object


    }

    [UnityTest]
    public IEnumerator TestToggle_ClosedToOpen()
    {
        var door = new GameObject().AddComponent<Door>();

        door.gameObject.AddComponent<SpriteRenderer>();
        door.gameObject.AddComponent<BoxCollider2D>();

        door.openSprite = Resources.Load<Sprite>("OpenSprite");
        door.closedSprite = Resources.Load<Sprite>("ClosedSprite");

        door.open = false;
        yield return null;

        door.Toggle();
        yield return null;

        Assert.IsTrue(door.open);           // check that door is now open

        var spriteRenderer = door.GetComponent<SpriteRenderer>();        // check that sprite is set to open sprite
        Assert.AreEqual(door.openSprite, spriteRenderer.sprite);

        var collider = door.GetComponent<BoxCollider2D>();        // check that collider is now disabled
        Assert.IsFalse(collider.enabled);

        UnityEngine.Object.Destroy(door.gameObject);        // clean up door game object


    }

}

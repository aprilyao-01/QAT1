using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class LeverTests
{
    [UnityTest]
    public IEnumerator Interact_TogglesDoors()
    {
        GameObject leverObject = new GameObject();
        Lever lever = leverObject.AddComponent<Lever>();
        Door[] doors = new Door[2];
        doors[0] = leverObject.AddComponent<Door>();
        doors[1] = leverObject.AddComponent<Door>();

        lever.doors = doors; // initialize the doors array
        doors[0].open = false;
        doors[1].open = false;

        //lever.Interact();                // act
        yield return new WaitForSeconds(1);

        Assert.AreEqual(true, doors[0].open);               // assert
        Assert.AreEqual(true, doors[1].open);

        UnityEngine.Object.Destroy(leverObject);            // clean up
    }

    [UnityTest]
    public IEnumerator Interact_FlipsSprite()
    {
        GameObject leverObject = new GameObject();
        Lever lever = leverObject.AddComponent<Lever>();
        leverObject.AddComponent<SpriteRenderer>(); // initialize the GetComponent<SpriteRenderer>()
        lever.GetComponent<SpriteRenderer>().flipX = false;

        lever.Interact();   // act
        yield return new WaitForSeconds(1);

        Assert.AreEqual(true, lever.GetComponent<SpriteRenderer>().flipX);                 // assert

        UnityEngine.Object.Destroy(leverObject);     // clean up
    }


}

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


public class PlayerControllTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void PlayerControllTestSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator TestOnMove_Horizontal_Input()
    {
        var player = new GameObject().AddComponent<PlayerController>();
        player.speed = 5;
        yield return null;

        Assert.AreEqual(5, player.transform.position.x, 0.1f);
    }
}

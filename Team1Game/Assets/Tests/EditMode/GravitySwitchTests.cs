using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GravitySwitchTests
{
    GameObject player1;
    GameObject player2;
    PlayerController playerController1;
    PlayerController playerController2;
    GravitySwitch gravitySwitch;

    [SetUp]         // @BeforeEach
    public void SetUp()
    {
        Debug.Log("SetUp");
        player1 = new GameObject();
        player2 = new GameObject();
        playerController1 = player1.AddComponent<PlayerController>();
        playerController2 = player2.AddComponent<PlayerController>();
        gravitySwitch = new GameObject().AddComponent<GravitySwitch>();
        Debug.Log(playerController2.flipped);
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
    public void TestInteract_ShouldFlipPlayers()
    {
        Debug.Log("TestInteract_ShouldFlipPlayers");

        playerController1.flipped = false;      // arrange
        playerController2.flipped = true;
        Debug.Log(playerController2.flipped);

        gravitySwitch.Interact();       // act
        Debug.Log(playerController2.flipped);

        Assert.AreEqual(playerController1.flipped, true);               // assert
        Assert.AreEqual(playerController2.flipped, false);
    }
}
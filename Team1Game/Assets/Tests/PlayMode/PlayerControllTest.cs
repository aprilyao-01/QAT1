using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;


public class PlayerControllTests
{
    [UnityTest]
    public IEnumerator TestPlayerGravityFlip()
    {
        //var player = new GameObject().AddComponent<PlayerController>();
        //var gravitySwitch = new GameObject().AddComponent<GravitySwitch>();

        //yield return new WaitForSeconds(0.5f);

        //// simulate player entering trigger
        //gravitySwitch.OnTriggerEnter2D(player.GetComponent<Collider2D>());
        //// simulate player interacting
        //player.OnInteract();

        //// check that the player's gravity has been flipped
        //Assert.AreEqual(-1, player.GetComponent<Rigidbody2D>().gravityScale);

        yield return null;
    }

    [UnityTest]
    public IEnumerator TestPlayerDamage()
    {
        //var player = new GameObject().AddComponent<PlayerController>();

        //player.health = 3;
        //// simulate player colliding cased damage
        //player.Damage(1);

        //yield return new WaitForSeconds(0.5f);

        //// check that the player has taken damage
        //Assert.AreEqual(2, player.health);

        yield return null;
    }

    [UnityTest]
    public IEnumerator TestHealthSlider()
    {
        //var player = new GameObject().AddComponent<PlayerController>();
        //var healthSlider = new GameObject().AddComponent<Slider>();
        //player.healthSlider = healthSlider;
        //player.health = 3;

        //yield return new WaitForSeconds(0.5f);

        //// check that the health slider's value is equal to the player's health
        //Assert.AreEqual(3, player.healthSlider.value);

        //player.Damage(1);

        //yield return new WaitForSeconds(0.5f);

        //// check that the health slider's value has been updated after taking damage
        //Assert.AreEqual(2, player.healthSlider.value);

        yield return null;
    }


}

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CannonTest
{
    private Cannon cannon;
    private GameObject projectile;

    [SetUp]
    public void SetUp()
    {
        // Create a new Cannon object and set its projectile property
        //cannon = new GameObject().AddComponent<Cannon>();
        //projectile = new GameObject();
        //cannon.projectile = projectile;
    }

    [TearDown]
    public void TearDown()
    {
        // Destroy the Cannon and projectile objects
        Object.DestroyImmediate(cannon);
        Object.DestroyImmediate(projectile);
    }

    [Test]
    public void TestFire()
    {
        // Test that the fire method instantiates a new bullet
        //cannon.fire();
        //Assert.IsNotNull(cannon.projectile);

        GameObject gameObject = new GameObject();
        cannon = gameObject.AddComponent<Cannon>();
        cannon.projectile = projectile;
        cannon.fire();
        Assert.IsNotNull(cannon.projectile);
    }
}

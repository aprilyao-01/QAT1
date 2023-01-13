using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CannonTest
{
    private Cannon cannon;
    private Bullet projectile;

    [SetUp]
    public void SetUp()
    {
        cannon = new GameObject().AddComponent<Cannon>();
        projectile = new GameObject().AddComponent<Bullet>();
        cannon.projectile = projectile;
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(cannon);
        Object.DestroyImmediate(projectile);
    }

    [Test]
    public void TestFire()
    {
        cannon.fire();
        Assert.IsNotNull(cannon.projectile);
    }
}

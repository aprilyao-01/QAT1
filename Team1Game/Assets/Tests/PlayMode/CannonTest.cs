using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CannonTest
{
    private Cannon cannon;
    private Bullet projectile;
<<<<<<< HEAD

=======
>>>>>>> 93ead64 (Fix merge conflicts)

    [SetUp]
    public void SetUp()
    {
        GameObject gameObject = new GameObject();
        cannon = gameObject.AddComponent<Cannon>();
        projectile = Resources.Load<Bullet>("Assets/Scripts/Bullet.cs");
        cannon.projectile = projectile;
    }

    [TearDown]
    public void TearDown()
    {
        UnityEngine.Object.Destroy(cannon);
        UnityEngine.Object.Destroy(projectile);
    }

    [UnityTest]
    public IEnumerator TestFire()
    {
        //// Test that the fire method instantiates a new bullet
        yield return new WaitForSeconds(1);
        cannon.Fire();
        yield return new WaitForSeconds(1);
        Assert.IsNotNull(cannon.projectile);
    }

    [UnityTest]
    public IEnumerator TestFireInterval()
    {
        // Test that the fire interval is set correctly
        yield return new WaitForSeconds(1);
        cannon.fireInterval = 0.5f;
        yield return new WaitForSeconds(1);
        Assert.AreEqual(0.5f, cannon.fireInterval);
    }

    [UnityTest]
    public IEnumerator TestFaceLeft()
    {
        // Test that the faceLeft property is set correctly
        yield return new WaitForSeconds(1);
        cannon.faceLeft = true;
        yield return new WaitForSeconds(1);
        Assert.IsTrue(cannon.faceLeft);
    }
}



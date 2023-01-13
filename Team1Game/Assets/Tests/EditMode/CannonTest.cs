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


    [SetUp]
    public void SetUp()
    {        cannon = new GameObject().AddComponent<Cannon>();
=======

    [SetUp]
    public void SetUp()
    {
        cannon = new GameObject().AddComponent<Cannon>();
>>>>>>> 93ead64 (Fix merge conflicts)
        projectile = new GameObject().AddComponent<Bullet>();
        cannon.projectile = projectile;
    }

    [TearDown]
    public void TearDown()
    {
<<<<<<< HEAD

=======
>>>>>>> 93ead64 (Fix merge conflicts)
        Object.DestroyImmediate(cannon);
        Object.DestroyImmediate(projectile);
    }

    [Test]
    public void TestFire()
    {
<<<<<<< HEAD
        cannon.Fire();
=======
        cannon.fire();
>>>>>>> 93ead64 (Fix merge conflicts)
        Assert.IsNotNull(cannon.projectile);
    }
}

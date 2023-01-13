using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.InputSystem;
using System;
using System.Reflection;

public class BulletTest
{
    private GameObject bulletObject;
    private Bullet bullet;
    private Rigidbody2D body;

    [UnitySetUp]        //BeforeEach
    public IEnumerator SetUp()
    {
        bulletObject = new GameObject();
        bulletObject.AddComponent<Bullet>();
        bullet = bulletObject.GetComponent<Bullet>();
        bulletObject.AddComponent<Rigidbody2D>();

        bullet.speed = 20;
        bullet.faceLeft = true;
        yield return null;
    }


    [UnityTearDown]      // @AfterEach
    public void TearDown()
    {
        GameObject.Destroy(bulletObject);
    }

    [UnityTest]
    public IEnumerator TestBulletFacingLeft()
    {
        bullet.speed = 10;  //arrange
        yield return new WaitForSeconds(1);     // act
        Assert.Less(bulletObject.transform.position.x, 0);      // assert
    }

    [UnityTest]
    public IEnumerator TestBulletSpeed()
    {
        float expectedSpeed = bullet.speed * Time.deltaTime; //arrange
        //yield return new WaitForSeconds(1);      // act
        //yield return new WaitForFixedUpdate();
        //yield return new WaitForEndOfFrame();
        //float actualSpeed = bulletObject.transform.position.x;
        //Assert.AreEqual(expectedSpeed, actualSpeed, 0.1f);      // assert
        yield return null;
    }

}

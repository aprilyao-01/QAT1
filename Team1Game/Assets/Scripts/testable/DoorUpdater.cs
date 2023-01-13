using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoorUpdater
<<<<<<< HEAD

=======
>>>>>>> aa3f2e4 (Fix merge conflicts)
{
    private Sprite openSprite;
    private Sprite closedSprite;
    private SpriteRenderer sprite;
    private GameObject doorGameObject;
<<<<<<< HEAD
    private BoxCollider2D col;
=======
    private Collider2D col;
>>>>>>> aa3f2e4 (Fix merge conflicts)

    public DoorUpdater(GameObject doorGameObject, bool open)
    {
        this.doorGameObject = doorGameObject;
        sprite = doorGameObject.GetComponent<SpriteRenderer>();
<<<<<<< HEAD
        col = doorGameObject.GetComponent<BoxCollider2D>();

=======
        col = doorGameObject.GetComponent<Collider2D>();
>>>>>>> aa3f2e4 (Fix merge conflicts)
        if (open)
        {
            sprite.sprite = openSprite;
            col.enabled = false;
        }

        //this.openSprite = openSprite;
        //this.closedSprite = closedSprite;
        //this.doorGameObject = doorGameObject;
        //sprite = doorGameObject.GetComponent<SpriteRenderer>();
        //col = doorGameObject.GetComponent<Collider2D>();
        //if (open)
        //{
        //    sprite.sprite = openSprite;
        //    col.enabled = false;
        //}

    }

    public void UpdateDoor(bool open)
    {
        if (open) sprite.sprite = openSprite;
        else sprite.sprite = closedSprite;
        col.enabled = !col.enabled;
    }
}

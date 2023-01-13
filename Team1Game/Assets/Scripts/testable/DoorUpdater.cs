using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoorUpdater

{
    private Sprite openSprite;
    private Sprite closedSprite;
    private SpriteRenderer sprite;
    private GameObject doorGameObject;
    private BoxCollider2D col;

    public DoorUpdater(GameObject doorGameObject, bool open)
    {
        this.doorGameObject = doorGameObject;
        sprite = doorGameObject.GetComponent<SpriteRenderer>();
        col = doorGameObject.GetComponent<BoxCollider2D>();
<<<<<<< HEAD
=======

>>>>>>> 16d943b (Fix merge conflicts)
        if (open)
        {
            sprite.sprite = openSprite;
            col.enabled = false;
        }
    }

    public void UpdateDoor(bool open)
    {
        if (open) sprite.sprite = openSprite;
        else sprite.sprite = closedSprite;
        col.enabled = !col.enabled;
    }
}

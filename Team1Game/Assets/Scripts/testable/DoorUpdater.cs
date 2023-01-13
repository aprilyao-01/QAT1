using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoorUpdater : MonoBehaviour
{
    private Sprite openSprite;
    private Sprite closedSprite;
    private SpriteRenderer sprite;
    private Collider2D col;
    public bool isOpen = false;

    public DoorUpdater(bool open)
    {
        sprite = this.GetComponent<SpriteRenderer>();        
        col = this.GetComponent<Collider2D>();
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

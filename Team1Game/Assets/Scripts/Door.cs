using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public Sprite openSprite;
    public Sprite closedSprite;
    public bool open = false;

    SpriteRenderer sprite;
    Collider2D col;

    public void Toggle()
    {
        open = !open;
        if(open) sprite.sprite = openSprite;
        else sprite.sprite = closedSprite;
        col.enabled = !col.enabled;
    }

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();

        if(open)
        {
            sprite.sprite = openSprite;
            col.enabled = false;
        }
    }

}

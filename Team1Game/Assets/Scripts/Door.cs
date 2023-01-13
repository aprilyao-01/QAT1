using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// Class <c>Door</c> derives from <c>MonoBehaviour</c>.
/// Handles behaviour of door object / prefab.
///</summary>
public class Door : MonoBehaviour
{

    public Sprite openSprite;
    public Sprite closedSprite;
    public bool open = false;

    SpriteRenderer sprite;
    Collider2D col;

    ///<summary>
    /// Method <c>Toggle</c> called when connected Lever is
    /// interacted with.
    /// Opens / closes the door.
    /// If open, changes to open sprite and disables collider.
    /// If closed, changes to closed sprite and enables collider.
    ///</summary>
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

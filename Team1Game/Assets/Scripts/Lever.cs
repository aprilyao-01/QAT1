using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// class <c>Lever</c> derives from <c>MonoBehaviour</c>,
/// implements <c>IInteractable</c>
/// Handles behaviour for interactable lever.
/// Toggles all connected doors on interact.
///</summary>
public class Lever : MonoBehaviour, IInteractable
{
    public Door[] doors;
    SpriteRenderer sprite;

    ///<summary>
    /// Method <c>Interact</c> called when player interacts
    /// with this object.
    /// Toggles all connected doors.
    ///</summary>
    public void Interact()
    {
        foreach (var door in doors) door.Toggle();
        sprite.flipX = !sprite.flipX;
        print("Lever toggled");
    }

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Called when trigger collider is entered
    void OnTriggerEnter2D(Collider2D col)
    {
        Enter(col);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        Exit(col);
    }




    // new add testable
    public void Enter(Collider2D col)
    {
        print("triggered");

        if (col.tag == "Player")
        {
            col.GetComponentInParent<PlayerController>().SetInteractable(this);
        }
    }

    public void Exit(Collider2D col)
    {
        print("untriggered");

        if (col.tag == "Player")
        {
            col.GetComponentInParent<PlayerController>().ClearInteractable();
        }
    }

    public void SetSprite(SpriteRenderer newSprite)
    {
        sprite = newSprite;
    }
}

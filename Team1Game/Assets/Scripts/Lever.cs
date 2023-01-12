using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour, IInteractable
{
    public Door[] doors;
    SpriteRenderer sprite;

    public void Interact()
    {
        foreach (var door in doors) door.Toggle();
        sprite.flipX = !sprite.flipX;
        print("Lever toggled");
    }

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        print("triggered");

        if(col.tag == "Player")
        {
            col.GetComponentInParent<PlayerController>().SetInteractable(this);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        print("untriggered");

        if(col.tag == "Player")
        {
            col.GetComponentInParent<PlayerController>().ClearInteractable();
        }
    }
}

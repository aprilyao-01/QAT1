using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// Class <c>GravitySwitch</c> derives from <c>MonoBehaviour</c>,
/// implements <c>IInteractable</c>.
/// Handles behaviour for interactable object, GravitySwitch.
/// Flips players' gravity when interacted with
///</summary>
public class GravitySwitch : MonoBehaviour, IInteractable
{
    ///<summary>
    /// Method <c>Interact</c> called when player interacts
    /// with this object.
    /// Flips gravity of all players.
    ///</summary>
    public void Interact()
    {
        PlayerController.FlipPlayers();
    }
    
    // Called when trigger collider is entered
    void OnTriggerEnter2D(Collider2D col)
    {
        // if collider is player, set this as its active interactable
        if(col.tag == "Player")
        {
            col.GetComponentInParent<PlayerController>().SetInteractable(this);
        }
    }

    // Called when trigger collider is exited
    void OnTriggerExit2D(Collider2D col)
    {
        // if collider is player, clear its active interactable
        if(col.tag == "Player")
        {
            col.GetComponentInParent<PlayerController>().ClearInteractable();
        }
    }

}

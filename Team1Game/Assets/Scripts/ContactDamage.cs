using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>ContactDamage</c> derives from <c>MonoBehaviour</c>.
/// Used by all enemies who deal contact damage.
/// Damages by player by specified number on each contact.
/// </summary>
public class ContactDamage : MonoBehaviour
{

    public int damage = 1;

    // called when trigger collider is entered.
    void OnTriggerEnter2D(Collider2D col)
    {
        // if collider is player, deal damage.
        if(col.tag == "Player")
        {
            col.GetComponentInParent<PlayerController>().Damage(damage);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

///<summary>
/// Class <c>MapExit</c>, derives from <c>MonoBehaviour</c>.
/// Handles MapExit object, which when entered by the player,
/// completes current level.
///<summary>
public class MapExit : MonoBehaviour
{

    public GameOverUI gameOverUI;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI gameOverButtonText;

    // called when trigger collider is entered
    void OnTriggerEnter2D(Collider2D col)
    {
        // if collider is player,
        // display level complete menu and pause game 
        if(col.tag == "Player")
        {
            Time.timeScale = 0;
            gameOverUI.gameObject.SetActive(true);
            gameOverUI.failed = false;
            gameOverText.SetText("Level Complete!");
            gameOverButtonText.SetText("Next Level");
        }
    }
}

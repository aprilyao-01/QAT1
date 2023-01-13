using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MapExit : MonoBehaviour
{

    public GameOverUI gameOverUI;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI gameOverButtonText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            gameOverUI.gameObject.SetActive(true);
            gameOverUI.failed = false;
            gameOverText.SetText("Level Complete!");
            gameOverButtonText.SetText("Next Level");
        }
    }
}

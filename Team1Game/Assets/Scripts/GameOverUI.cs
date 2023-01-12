using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{

    public bool failed = false;
    public Scene nextLevel;
    public Scene mainMenu;
    public void OnButtonClick()
    {
        if(failed)
            {
                SceneManager.LoadScene( SceneManager.GetActiveScene().name );
                return;
            }
        SceneManager.LoadScene( nextLevel.name );
    }

    public void onMenuButtonClick()
    {
        SceneManager.LoadScene( mainMenu.name );
    }
}

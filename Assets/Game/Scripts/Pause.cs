using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public Canvas pauseCanvas;

    
   public void pauseGame()
    {
        pauseCanvas.enabled = true;
        Time.timeScale = 0;
    }

    public void resumeGame()
    {
        pauseCanvas.enabled = false;
        Time.timeScale = 1;
    }

    public void backMenu()
    {
        Time.timeScale = 1;
        LevelLoader.loadLevel("MainMenu");
        
    }
}

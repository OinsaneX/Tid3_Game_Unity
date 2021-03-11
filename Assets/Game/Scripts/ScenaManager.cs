using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenaManager : MonoBehaviour
{
    // Start is called before the first frame update
   

    // Update is called once per frame
    
    public void NewGame()
    {
        LevelLoader.loadLevel("Level1");
    }
    
    public void doExitGame()
    {
        Application.Quit();
    }
}

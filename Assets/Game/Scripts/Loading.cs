using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string levelToload = LevelLoader.nextLevel;
        StartCoroutine(this.MakeTheLoad(levelToload));
    }

    // Update is called once per frame
   IEnumerator MakeTheLoad(string level)
    {
        yield return new WaitForSeconds(1f);
       AsyncOperation operation = SceneManager.LoadSceneAsync(level);

        while (!operation.isDone == false)
        {
            yield return null;
        }
    }
}

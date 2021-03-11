using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answerbutton : MonoBehaviour
{
    Answer DataAnswer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextDialog()
    {
        FindObjectOfType<DialogController>().NextDialog(DataAnswer.nextDialog);
    }
    public void Setup (Answer answer)
    {
        DataAnswer = answer;
    }
}

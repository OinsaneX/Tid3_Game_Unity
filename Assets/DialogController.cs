using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    public GameObject PanelDialog;
    public Text dialogNpc;
    public GameObject Answer;
    private bool dialogActive = false;
    DialogNpc dialogs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && dialogActive)
        {
            if (dialogs.answers.Length > 0)
                showAnswer();
            else
            {
                dialogActive = false;
                PanelDialog.SetActive(false);
                dialogNpc.gameObject.SetActive(false);
                FindObjectOfType<PlayerController>().Move = true;

            }
        }
    }

    void showAnswer()
    {
        dialogNpc.gameObject.SetActive(false);
        dialogActive = false;

        for(int i = 0; i < dialogs.answers.Length; i++)
        {
            GameObject tempAnswer = Instantiate(Answer, PanelDialog.transform) as GameObject;
            tempAnswer.GetComponent<Text>().text = dialogs.answers[i].answer;
            tempAnswer.GetComponent<Answerbutton>().Setup(dialogs.answers[i]);
        }
    }

    public void NextDialog(DialogNpc dialog)
    {
        dialogs = dialog;

        clearAnswers();
        dialogActive = true;
        PanelDialog.gameObject.SetActive(true);
        dialogNpc.gameObject.SetActive(true);

        dialogNpc.text = dialogs.dialog;
    }

    public void clearAnswers()
    {
        Answerbutton[] buttons = FindObjectsOfType<Answerbutton>();
        foreach(Answerbutton button in buttons)
        {
            Destroy(button.gameObject);
        }
    }
}

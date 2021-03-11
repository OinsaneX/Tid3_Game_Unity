using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{

    public DialogNpc[] dialogs = new DialogNpc[2];

    private bool dialogFinished = false;

    DialogController dialogController;

    // Start is called before the first frame update
    void Start()
    {
        dialogController = FindObjectOfType<DialogController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().Move = false;
            collision.GetComponent<PlayerController>().anim.SetFloat("Speed",0);



            if (!dialogFinished)
            {
                dialogController.NextDialog(dialogs[0]);
            }
            else
            {
                dialogController.NextDialog(dialogs[1]);
            }
            dialogFinished = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy : MonoBehaviour
{
    public float Speed;
    private Transform target;
    float verticalMove = 0;
    float horizontalMove = 0;
    public Joystick joystick;



    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        verticalMove = joystick.Vertical * Speed;
        horizontalMove = joystick.Horizontal * Speed;

        if(horizontalMove==0 && verticalMove == 0)
        {
            if (Vector2.Distance(transform.position, target.position) > 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);

            }
        }
        else
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x+horizontalMove,target.position.y+verticalMove), Speed * Time.deltaTime);
        /* if(Vector2.Distance(transform.position, target.position)>1)
         {

                 transform.position = Vector2.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);




         }

        */


    }

  
}

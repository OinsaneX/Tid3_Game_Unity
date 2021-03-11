using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [System.Serializable]
    public struct Stat
    {
        public int currentValor;
        public int maxValue;
    }

    public Stat health;
    public Stat mana;
    public Animator anim;
    private float Speed = 1f;
    private Rigidbody2D _rigibody;
    public bool Move = true;
    private float jumpForce = 5f;
    private bool grounded = true;
    private bool running = false;
    public AudioSource audio;
    public int experience;
    public const int MaxExperience = 100;
    public Joystick joystick;
    



    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        _rigibody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        MovementFunctions();
       
    }
   

    private void MovementFunctions()
    {

        
          
              var movement = joystick.Horizontal*2;
        
          

            anim.SetFloat("Speed", Mathf.Abs(movement * Speed));

                transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * Speed;
            


            if (!Mathf.Approximately(0, movement))
            {
                transform.rotation = movement > 0 ? Quaternion.identity : Quaternion.Euler(0, 180, 0);
            }

            if (Input.GetButton("Fire3"))
            {
                running = true;
            }
            else
            {
                running = false;
            }

            if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigibody.velocity.y) < 0.01f)
            {
                anim.SetTrigger("Jump");
                _rigibody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

            }
        

    }


    private void PlayerSkills() { 

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
            anim.SetBool("Ground",false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if (!grounded)
            {
                audio.Play();
            }
            grounded = true;
            anim.SetBool("Ground",true);
        }
    }



    public void ChangeHealth(int value)
    {
        health.currentValor = Mathf.Clamp(health.currentValor + value, 0, health.maxValue);
    }
    public void ChangeMana(int value)
    {
        mana.currentValor = Mathf.Clamp(mana.currentValor + value, 0, mana.maxValue);
    }

    public void AddExperience(int value)
    {
        experience += value;
        if (experience > MaxExperience)
        {
            experience = 0;
        }
    }


    public void Jump()
    {
        if(Mathf.Abs(_rigibody.velocity.y) < 0.01f)
        {
            anim.SetTrigger("Jump");
            _rigibody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

        }
    }
}

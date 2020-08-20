using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

//Author: Frorb

public class Player: MonoBehaviour
{
    public float speed = 3;
    public float maxHP = 10;

    //hurt audio
    //dead audio
    //Vector2 movementunit = Vector2.zero;
    Rigidbody2D ridgidbody;//Uses the Object's Rigidbody2D -ApricotLOL
    SpriteRenderer spriteren;
    [SerializeField]
    Sprite[] sprites;

    float currentHP;
    public bool Dead = false; // Game Manager needs to know if player isdead -ApricotLOL
    // Start is called before the first frame update
    void Start()
    {
        ridgidbody = GetComponent<Rigidbody2D>();
        currentHP = maxHP;
        spriteren = GetComponent<SpriteRenderer>();
        MainMenuController menu = GameObject.Find("MainMenu").GetComponent<MainMenuController>();
        int aux = menu.selectedAvatar();
        if (aux == 0) spriteren.sprite = sprites[0];
        else spriteren.sprite = sprites[1];
        menu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 movementaux = Vector2.zero;
        if (Input.GetKey(KeyCode.W)) movementaux += Vector2.up;
        if (Input.GetKey(KeyCode.A)) movementaux += Vector2.left;
        if (Input.GetKey(KeyCode.S)) movementaux += Vector2.down;
        if (Input.GetKey(KeyCode.D)) movementaux += Vector2.right;
        movementaux = movementaux.normalized;
        if (movementaux != Vector2.zero)
        {
            ridgidbody.MovePosition(ridgidbody.position + movementaux * speed * Time.fixedDeltaTime);
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var scr = collision.gameObject.GetComponent<ThresholdTrigger>();
        if (scr != null && scr.released) //chechk collision type
        {

            if (currentHP > 0) {
                currentHP -= 1;
            }
            else {
                setDead(true);
            }
            //play audio of player getting hit
            

            //Debug.Log("HP: " + currentHP);
            //rigidbody.MoveRotation(0f);
           
            

        }
    }

    /*
    private void OnCollisionExit2D(Collision2D collision)
    {
        rigidbody.MoveRotation(0f);
    }
    */

    public void resetHP()
    {//-ApricotLOL
        currentHP = maxHP;
    }
    public void setMaxHP(float newMax)
    {//-ApricotLOL
        maxHP = newMax;
    }
    public int getCurrentHP()
    {//-ApricotLOL
        return (int)currentHP;
    }
    public void damageHP(float damage)
    {//-ApricotLOL
        currentHP =- damage;
    }
    public void setSpeed(float newSpeed)
    {//-ApricotLOL
        speed = newSpeed;
    }
    public void setDead(bool flag)
    {//-ApricotLOL
        Dead = flag;
    }
    public bool isDead()
    {//-ApricotLOL
        return Dead;
    }




}

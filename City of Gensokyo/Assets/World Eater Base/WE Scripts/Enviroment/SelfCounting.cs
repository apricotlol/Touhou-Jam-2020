using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author: ApricotLOL

//add this to ALL Eviroment Objects

public class SelfCounting : MonoBehaviour
{//this talks to the Game Manager to count itself to the list of objects
    GameManager gm;

    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        gm.foodBlackHole++;//counts how much food is in the game
    }
    void Start()
    {
       
    }


    public void OnDestroy()
    {
        gm.foodBlackHole--;//removes self from counted food
    }

    void Update()
    {
        
    }


}

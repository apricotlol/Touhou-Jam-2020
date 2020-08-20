using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author: ApricotLOL
//was gonna make proper AI but fuckit I don't have time perhaps after the jam
public class JankMachine : MonoBehaviour
{   
    public PlayerSpells playermagic; //I want to know the mana
    bool moodNeutral = true;
    bool moodConfused = false;
    bool moodHostile = false;

    public BlackHoleActions blackHoleActions;
    public float elaspedTime;
    public float maxTimeOfMood;//we cab also connect it to the player maxMana points
    int randomInt = 0;
    public Transform playerTransformPos;
    float actionTimer;
    public float actionRateConfused;
    public float actionRateHostile;
    public float wanderRange;
    void Start() {
        elaspedTime = 0;
        
    }
    void Update()
    {

        elaspedTime += Time.deltaTime;
        actionTimer += Time.deltaTime;
        Vector2 wanderPos = new Vector2((Random.Range((wanderRange * -1.0f), wanderRange)), (Random.Range((wanderRange * -1.0f), wanderRange)));
        if (moodNeutral)//neutral mood is initialized so this should happen first
        {
            if ((elaspedTime > playermagic.getmana()) && (elaspedTime < maxTimeOfMood))
            {//elapsed time less than amount of mana, and less than maximum amount of time
                getAnyMood();
            }
        }
        else if (moodConfused)
        {
            if (actionTimer > actionRateConfused)
            {
                blackHoleActions.gotopos(wanderPos);
                actionTimer = 0.0f;
            }
            attemptToCalmDown();
            //confused states

        }
        else if (moodHostile) {
            if (actionTimer > actionRateHostile)
            { 
                
                blackHoleActions.chase(playerTransformPos);
                actionTimer = 0.0f;
            }

            attemptToCalmDown();

            //hostile states
        }
        
    }

    private void getAnyMood() {
       randomInt = Random.Range(1, 3);
        switch (randomInt) {
            case 1:
                Debug.Log("is now confused");
                setMood(false, true, false);//set to confused
                break;
            case 2:
                Debug.Log("is now hostile");
                setMood(false, false, true);//set to hostile
                break;
            default:
                Debug.Log("something went wrong, getAnyMood default error");
                break;
        }
    }

    public int checkMood() {
        if (moodNeutral) {
            return 0;
        }

        if (moodConfused)
        {
            return 1;
        }

        if (moodHostile)
        {
            return 2;
        }

        return -1; //this is BAD
    }

    public void setMood(bool neutral,bool confused,bool hostile) {//stupid ass design fix this shitty ass design after the jam
        moodNeutral = neutral;
        moodConfused = confused;
        moodHostile = hostile;    
    }
    public void attemptToCalmDown() {
        if (elaspedTime > maxTimeOfMood)
        {
            setMood(true, false, false);//mood is neutral
            Debug.Log("is now neutral");
            elaspedTime = 0.0f;//or elaspedTime greater than MaxTime(return to stable)
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TurnBasedBattle : MonoBehaviour
{

    public Band playerBand;
    public Band enemyBand;

    public bool playerWon = false;
    public bool enemyWon = false;

    // Called when player submits a combat action
    public void performPlayerAction(string actionIdentifier)
    {
        actionIdentifier = actionIdentifier.ToLower();
        switch (actionIdentifier)
        {
            case "guitar":
                if(enemyBand.getBandState() == "singer")
                {
                    playerBand.setBandState("guitar");
                    playerWon = enemyBand.updateHealth(-50);
                }
                break;
            case "singer":
                if(enemyBand.getBandState() == "drummer")
                {
                    playerBand.setBandState("singer");
                    playerWon = enemyBand.updateHealth(-50);
                }
                break;
            case "drummer":
                if(enemyBand.getBandState() == "guitar")
                {
                    playerBand.setBandState("drummer");
                    playerWon = enemyBand.updateHealth(-50);
                }
                break;
        }
    }

        public void performEnemyAction(int actionIdentifier)
    {
        switch (actionIdentifier)
        {
            case 1:
                if(playerBand.getBandState() == "singer")
                {
                    enemyBand.setBandState("guitar");
                    enemyWon = playerBand.updateHealth(-50);
                }
                break;
            case 2:
                if(playerBand.getBandState() == "drummer")
                {
                    enemyBand.setBandState("singer");
                    enemyWon = playerBand.updateHealth(-50);
                }
                break;
            case 3:
                if(playerBand.getBandState() == "guitar")
                {
                    enemyBand.setBandState("drummer");
                    enemyWon = playerBand.updateHealth(-50);
                }
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        while(!playerWon || !enemyWon)
        {
            Debug.Log("Player Turn");
            // get player input
            performPlayerAction("guitar");
            if(playerWon) break;
            int enemyAction = Random.Range(1,4);
            performEnemyAction(enemyAction);
        }
    }

    // Update is called once per frame
    void Update()
    {
       if(playerBand.health <= 0)
       {
           Debug.Log("Player has won");
       }
       else if(enemyBand.health <= 0)
       {
           Debug.Log("Enemy has won");
       }
    }
}

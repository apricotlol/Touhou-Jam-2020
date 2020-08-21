using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class TurnBasedBattle : MonoBehaviour
{

    public Band playerBand;
    public Band enemyBand;

    public Button guitar_B;
    public Button singer_B;
    public Button drummer_B;
  
    UnityEvent m_MyEvent = new UnityEvent();
    public int enemyAction;

    public bool playerWon = false;
    public bool enemyWon = false;

    void Start()
    {
        playerBand.setBandMember("null");
        guitar_B.onClick.AddListener(GuitarClick);
        singer_B.onClick.AddListener(SingerClick);
        guitar_B.onClick.AddListener(DrummerClick);
        enemyAction = Random.Range(1, 4);
    }

    public void performCombat() {
        enemyAction = Random.Range(1, 4);
        performPlayerAction(playerBand.getBandMember());
        performEnemyAction(enemyAction);
        Debug.Log(playerBand.health + "   " + enemyBand.health);
    }

    public void performPlayerAction(string actionIdentifier)
    {
        actionIdentifier = actionIdentifier.ToLower();//helps prevent syntax errors
        switch (actionIdentifier)
        {
            case "guitar":
                if(enemyBand.getBandMember() == "singer")
                {
                    Debug.Log("guitar attack successful!");
                    
                    playerWon = enemyBand.updateHealth(-50);
                }
                break;
            case "singer":
                if(enemyBand.getBandMember() == "drummer")
                {
                    
                    playerWon = enemyBand.updateHealth(-50);
                }
                break;
            case "drummer":
                if(enemyBand.getBandMember() == "guitar")
                {
                    
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
                enemyBand.setBandMember("guitar");
                if (playerBand.getBandMember() == "singer")
                {
                    enemyWon = playerBand.updateHealth(-50);
                }
                break;
            case 2:
                enemyBand.setBandMember("singer");
                if (playerBand.getBandMember() == "drummer")
                {     
                    enemyWon = playerBand.updateHealth(-50);
                }
                break;
            case 3:
                enemyBand.setBandMember("drummer");
                if (playerBand.getBandMember() == "guitar")
                {     
                    enemyWon = playerBand.updateHealth(-50);
                }
                break;
        }
    }


    public void GuitarClick()
    {
        playerBand.setBandMember("guitar");
        performCombat();
    }
    public void SingerClick()
    {
        playerBand.setBandMember("singer");
        performCombat();
    }
    public void DrummerClick()
    {
        playerBand.setBandMember("drummer");
        performCombat();
    }

    void Update()
    {

        if (!playerWon || !enemyWon)
        {
            playerBand.setBandMember("null");
        }

        if (enemyBand.health <= 0)
       {
           Debug.Log("Player has won");
       }
       else if(playerBand.health <= 0)
       {
           Debug.Log("Enemy has won");
       }
    }

    void getbandaction()
    {

    }

}

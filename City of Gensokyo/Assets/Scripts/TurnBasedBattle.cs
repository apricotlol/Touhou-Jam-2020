using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBasedBattle : MonoBehaviour
{

    private Band playerBand;
    private Band enemyBand;

    public TurnBasedBattle(Band pb, Band eb)
    {
        playerBand = pb;
        enemyBand = eb;
    }

    public TurnBasedBattle()
    {
        playerBand = new Band();
        enemyBand = new Band();
    }

    // Called when player submits a combat action
    public void performPlayerAction(string actionIdentifier)
    {
        actionIdentifier = actionIdentifier.ToLower();
        switch (actionIdentifier)
        {
            case "attack":
                enemyBand.updateHealth(-50);
                playerBand.updateEnergy(-20);
                break;
            case "rest":
                playerBand.updateEnergy(50);
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}

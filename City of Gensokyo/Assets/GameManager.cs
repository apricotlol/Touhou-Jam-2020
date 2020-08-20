using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    /// <summary>~
    /// Game States~
    ///     Running~
    ///         Game is not running in a end state~
    ///     End State~
    ///         Win~
    ///             X number of items left in the map~
    ///             OR~
    ///             Black Hole has reached certain size~
    ///         Lose~
    ///             Player HP is ZERO~
    ///             Black hole has shrunk~
    ///         Game will pause when we reach these states~
    ///             Give player the option to reset the level~
    /// ~
    /// Things to track~
    ///     1.Player~
    ///         HP~
    ///     2.Black hole~
    ///         Mood state~
    ///     3.Self: Game State~
    ///         Running~
    ///         End State~
    ///             Win~
    ///             Lose~
    ///         
    /// MORE TO DO:      
    /// Music DJ 
    ///     Run music from given list
    ///     While running
    ///         Game Manager checks the Black hole mood
    ///             Plays music based on the mood
    ///     While in End State 
    ///     
    /// Optional:
    /// Dialogue Machine
    ///     Check player
    ///         When player does a certain action
    ///             Dialogue bubble opens displays String of Dialogue
    ///                 Dialogue bubble can be in from the blackhole or the player
    ///     
    /// </summary>

    public Text endScreen;
    public Text playerHP;
    public Text foodUI;
    public bool StateRunning = true;
    private bool StateEndGame = false;
    public Player player;
    public int foodBlackHole = 0;
    int foodTotal;
    public float winPercentage = 0.9f;//90% will be the defualt
    float foodPercentage = 0;

    //public StateMachine BlackHole;//we need to get the script to read states
    private void Awake()
    {
        player.resetHP();
        endScreen.text = " ";
        foodUI.text = " ";
    }

    void Start()
    {
        foodTotal = foodBlackHole;
        foodPercentage = (float)foodBlackHole / (float)foodTotal;

    }
    // Update is called once per frame
    void Update()
    {
        if (!(StateRunning) && !(StateEndGame)) {
            //open menu
        }
        if (StateRunning){//consider instatiation of objects... if possible
            onPlay();
        }
        if (StateEndGame) {
            StateRunning = false;
            //Show menue
            //consider pausing the game and opening menu after a timer or user presses any key
        }
    }

    private void onPlay() {

        foodPercentage = (float)foodBlackHole / (float)foodTotal;//p% y x
        float consumed = 1.0f - foodPercentage;
        playerHP.text = player.getCurrentHP().ToString();
        
        string foodPercentageStr = string.Format("Percentage of consumable objects eaten {0:0.0%}", consumed); //(float)foodBlackHole / (float)foodTotal)
        string winPercentText = string.Format("Must consume {0:0.0%}", winPercentage);
        foodUI.text = foodBlackHole.ToString() + " / " + foodTotal.ToString() + " \n" + foodPercentageStr + " \n" + winPercentText ;

        if (player.isDead())
        {//player loses
            StateEndGame = true;
            endScreen.text = "You Lose";
        }
        //if(blackhole is dead)
        //  StateEndGame=True;
        //  endScreen.text = "You Lose";
        if (consumed >= winPercentage) {
            StateEndGame = true;
            endScreen.text = "You WIN";
        }
      
    }



    void pauseGame()
    {
        //have a UI that makes changes
        Time.timeScale = 0;  
    }
    void UnpauseGame()
    {
        //have a UI that makes changes
        Time.timeScale = 0;
    }
}


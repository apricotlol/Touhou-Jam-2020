using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuotesBase
{
    public string[] beggining;
    public string[] middle;
    public string[] endgame1;
    public string[] endgame2;
    public string[] gameover1;
    public string[] gameover2;
    public string[] gameover3;
    /*
    public string[] orderMove;
    public string[] orderStop;
    public string[] orderCome;
    public string[] orderExplode;
    */

    public abstract void instantiate();
    
}


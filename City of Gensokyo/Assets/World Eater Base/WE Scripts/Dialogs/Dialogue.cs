using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class Dialogue
{
    static QuotesBase currentChar;
    // Start is called before the first frame update
    public static void setCharacter(int charNum)
    {
        if (charNum == 0)
        {
            currentChar = new QuotesSingularity();
        }
        else return;
        currentChar.instantiate();
    }
    public static string returnDialogue(int i)
    {
        if (currentChar == null) return "notFound";
        else return "notFound2";
    }
}


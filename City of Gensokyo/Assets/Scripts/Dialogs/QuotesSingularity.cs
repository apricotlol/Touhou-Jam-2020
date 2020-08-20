using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuotesSingularity : QuotesBase
{
    public override void instantiate() {
        beggining = new string[3]{"First part, success. Second part, starting!",
                "So this is what true darkness looks like…",
                "Let the experiment begin!"};
        middle = new string[3]{"What? This thing is alive?",
                "That’s way more interesting now!",
                "You may be alive, but you work for me!" };
        endgame1 = new string[3] { "No! Continue! You can’t die now!",
                "This is not the time to rest!",
                "We have still work to do !"};
        endgame2 = new string[3] {"Hahah… I have… the control.",
                "I am the power! You are a mere puppet!",
                "Obey me! You don’t have any other choices!" };
        gameover1 = new string[3] {"Experiment: Over.",
                "Time to pay the Devil now.",
                "That was pretty interesting." };
        gameover2 = new string[3] { "What the -",
                "How is it possible?",
                "Where are we now?"};
        gameover3 = new string[3] {"Impossib-Aaaah!",
                "I am the night! Noooo!",
                "So that’s what damnation looks like..." };
    }

    /*Ordering Move:
“Go my servant!”
“Show them the power of Darkness!”
“I send the hell”

Ordering to stay in place:
“The Darkness shall rest”
“Now be quiet!”
“I order you to wait!”

Ordering explosions:
“Unleash your power!”
“Show them the power of Gravity!”
“We have become Death, the destroyer of Worlds!”

Ordering to come closer:
“Come meet your master!”
“I need to see you.”
“Give me the answers I seek.”

Spell using:
“Let me show what the void is!”
“By the devil’s power, I shall experiment!”
“I will show you true physics!”

Taking items:
“This is mine now.”
“Let’s examine this.”
“This is an interesting object...”

Throwing items:
“I don’t need it anymore.”
“What effect will it have?”
“This might do some damages… Fascinating.”*/

}

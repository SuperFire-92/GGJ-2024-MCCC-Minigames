using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelList
{
    //If you add a new minigame, create a new reference in here, with the preferred name being the first
    //string, and the scene name being the second string. This should keep everything sorted and let us
    //keep a naming system without having to go and rename every scene.
    private static Dictionary<string, string> dictionary = new Dictionary<string, string>()
    {
        {"level1", "WheresWaldo"},
        {"level2", "wiibalanceboard" },
        {"level3", "BowMinigame" },
        {"level4", "TrashBasketBall" },
        {"level5", "WizardFireball" },
        {"level6", "KillAliens" },
        {"level7", "FlashlightGame" },
        {"level8", "AvoidFallingObjects" },
        {"level9", "KTB" },
        {"Level10", "BounceMinigame" },
        {"Level11", "arrowmatch" },
        {"Level12", "WordType" },
        {"Level13", "TurtleRacer" },
        {"Level15", "Trivia" }

    };

    public const string theGame = "TheGame";

    private static int prevLevelIndex = -1;

    public static string getRandomLevel()
    {
        Dictionary<string, string>.ValueCollection vals = dictionary.Values;
        int rand;
        //Ensure the new minigame is not repeating the previous one
        do
        {
            rand = Random.Range(0, vals.Count);
        } while (rand == prevLevelIndex);
        //Store the index of the coming level
        prevLevelIndex = rand;
        int i = 0;
        foreach(string s in vals)
        {
            if (rand == i)
            {
                return s;
            }
            i++;
        }
        return null;
    }
}

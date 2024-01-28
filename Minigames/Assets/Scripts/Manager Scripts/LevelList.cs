using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Level
{
    public string sceneName;
    public string instruction;

    // Makes game not use default menu
    public bool uniqueMenu;

    public Level(string i, string sN)
    {
        instruction = i;
        sceneName = sN;
        uniqueMenu = false;
    }

    public Level(string i, string sN, bool uM)
    {
        instruction = i;
        sceneName = sN;
        uniqueMenu = uM;
    }
}

public static class LevelList
{
    // we balling - Brad Hanson
    // instructions are given to the GameManager inside MiniGameBouncer.cs
    public static Level[] levels = new Level[]
    {
        new Level("Find me!", "WheresWaldo"),
        new Level("Balance!", "wiibalanceboard"),
        new Level("Hit the apple!", "BowMinigame"),
        new Level("Shoot a basket!", "TrashBasketBall"),
        new Level("Kill them all!", "WizardFireball"),
        new Level("Kill them all!", "KillAliens"),
        new Level("Find me!", "FlashlightGame"),
        new Level("Avoid the falling objects!", "AvoidFallingObjects"),
        new Level("Kick the ball!", "KTB"),
        new Level("Collect them!", "BounceMinigame"),
        new Level("Match the keys!", "arrowmatch", true),
        new Level("Type The Word On Screen", "WordType", true),
        new Level("Mash!", "TurtleRacer"),
        new Level("Give a smooch!", "GiveASmooch"),
        new Level("Answer correctly!", "Trivia"),
        new Level("Mash!", "Jackinthebox"),
        new Level("Click your response!", "RockPaperScissors"),
        new Level("Hit the birds!", "FlappyPipe"),
        new Level("Don't sniff it!", "BearFart"),
        new Level("Don't get zapped!", "FollowTheLine"),
        //new Level("instruction", "pinapplepizza")
    };


    //If you add a new minigame, create a new reference in here, with the preferred name being the first
    //string, and the scene name being the second string. This should keep everything sorted and let us
    //keep a naming system without having to go and rename every scene.
    //private static ArrayList<string, string> dictionary = new ArrayList<string, string>()
    //{
    //    {"level1", "WheresWaldo"},
    //    {"level2", "wiibalanceboard" },
    //    {"level3", "BowMinigame" },
    //    {"level4", "TrashBasketBall" },
    //    {"level5", "WizardFireball" },
    //    {"level6", "KillAliens" },
    //    {"level7", "FlashlightGame" },
    //    {"level8", "AvoidFallingObjects" },
    //    {"level9", "KTB" },
    //    {"level10", "BounceMinigame" },
    //    {"level11", "arrowmatch" },
    //    {"level12", "WordType" },
    //    {"level13", "TurtleRacer" },
    //    {"level14", "GiveASmooch" },
    //    {"level15", "Trivia" },
    //    {"level16", "Jackinthebox" },
    //    {"level17", "RockPaperScissors" },
    //    {"level18", "FlappyPipe" },
    //    {"level19", "BearFart" },
    //    {"level20", "FollowTheLine" }
    //};

    public const string theGame = "TheGame";

    private static int prevLevelIndex = -1;

    public static Level getRandomLevel()
    {
        int rand;
        //Ensure the new minigame is not repeating the previous one
        do
        {
            rand = Random.Range(0, levels.Length);
        } while (rand == prevLevelIndex);
        //Store the index of the coming level
        prevLevelIndex = rand;
        int i = 0;
        foreach(Level s in levels)
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameManager
{
    private static int score;
    private static float speed;
    private static int lives;
    private static int speedIncrease = 5;

    public static void resetGame()
    {
        score = 0;
        lives = 3;
        speed = 6;
    }

    public static void addScore(int value)
    {
        score += value;
        if (score % speedIncrease == 0 && speed > 3)
        {
            speed--;
        }
    }
    
    public static int getScore()
    {
        return score;
    }

    public static void endMiniGame(bool win)
    {
        if (win)
        {
            score++;
            SceneManager.LoadScene(LevelList.theGame);
        }
        else
        {
            lives--;
            SceneManager.LoadScene(LevelList.theGame);
        }
    }
}

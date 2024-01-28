using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameManager
{
    private static int score;
    private static float speed = 1;
    private static int lives = 5;
    private static int speedIncrease = 3;
    //0 - Still playing, 1 - Win, 2 - Loss
    public static int gameStatus = 0;

    public static void resetGame()
    {
        score = 0;
        lives = 5;
        speed = 1;
    }

    public static void addScore(int value)
    {
        score += value;
        if (score % speedIncrease == 0 && speed > 0.7)
        {
            speed -= 0.03f;
        }
    }
    
    public static int getScore()
    {
        return score;
    }

    //TO BE USED TO END ANY MINIGAME
    //Tell it false if the player lost (mainly done when the timer runs out)
    //Tell it true to say the player won the minigame, and to lead back to the game scene
    public static void endMiniGame(bool win)
    {
        if (win && gameStatus == 0)
        {
            addScore(1);
            gameStatus = 1;
        }
        else if (gameStatus == 0)
        {
            lives--;
            gameStatus = 2;
            Debug.Log("Your lives = " + lives);

            if (lives <= 0)
            {
                //SceneManager.LoadScene("MainMenu");
            }
        }
    }

    public static void returnToMainGame()
    {
        SceneManager.LoadScene(LevelList.theGame);
    }

    public static float getSpeed()
    {
        return speed;
    }

    public static int getLives()
    {
        return lives;
    }
}

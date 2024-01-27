using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [Header("Info")]
    [SerializeField] float timerLength;
    [SerializeField] bool timerKill;
    [SerializeField] bool ignoreMultiplier;
    [SerializeField] bool waitToStart;

    [Header("References")]
    [SerializeField] TextMeshProUGUI timeDisplay;

    private void Start()
    {
        if (!ignoreMultiplier)
        {
            timerLength = timerLength * GameManager.getSpeed();
        }
        
        GameManager.gameStatus = 0;
    }

    private void Update()
    {
        if (!waitToStart)
        {
            timerLength -= Time.deltaTime;
            if (GameManager.gameStatus != 0)
            {
                timeDisplay.text = (GameManager.gameStatus == 1 ? "WIN" : "LOSE");
                if (timerLength > 1f)
                {
                    timerLength = 1f;
                }
            }
            else
            {
                if (Mathf.FloorToInt(timerLength).ToString() == "-1")
                {
                    timeDisplay.text = "0";
                }
                else
                {
                    timeDisplay.text = Mathf.FloorToInt(timerLength).ToString();
                }
                
            }
        
            if (timerLength <= 0) 
            {
                GameManager.returnToMainGame();
            }
        }
    }

    public void startTimer()
    {
        waitToStart = false;
    }
}

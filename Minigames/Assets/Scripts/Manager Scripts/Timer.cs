using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [Header("Info")]
    [SerializeField] float timerLength;
    [SerializeField] bool timerKill;
    [SerializeField] bool ignoreMultiplier;

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
            timeDisplay.text = Mathf.FloorToInt(timerLength).ToString();
        }
        
        if (timerLength <= 0) 
        {
            GameManager.returnToMainGame();
        }
        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timerLength;

    private void Start()
    {
        timerLength = timerLength * GameManager.getSpeed();
    }

    private void Update()
    {
        timerLength -= Time.deltaTime;
        if (timerLength <= 0) 
        {
            GameManager.endMiniGame(false);
        }
    }
}

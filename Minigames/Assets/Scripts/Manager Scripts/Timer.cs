using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [Header("Info")]
    [SerializeField] float timerLength;
    [SerializeField] bool timerKill;

    private void Start()
    {
        timerLength = timerLength * GameManager.getSpeed();
    }

    private void Update()
    {
        timerLength -= Time.deltaTime;
        if (timerLength <= 0) 
        {
            GameManager.endMiniGame(!timerKill);
        }
    }

}

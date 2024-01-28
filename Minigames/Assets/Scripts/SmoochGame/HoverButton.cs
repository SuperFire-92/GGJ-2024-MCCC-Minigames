using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverButton : MonoBehaviour
{
    [NonSerialized] public bool gameStarted;
    [SerializeField] private GameObject timer;

    private void Start()
    {
        gameStarted = false;
    }

    private void OnMouseEnter()
    {
        gameStarted = true;
        timer.GetComponent<Timer>().startTimer();
        GetComponent<Renderer>().material.color = new Color(1f,0f,0f,0f);
    }
}

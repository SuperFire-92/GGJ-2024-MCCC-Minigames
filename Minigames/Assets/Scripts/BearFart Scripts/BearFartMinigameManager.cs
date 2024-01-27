using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearFartMinigameManager : MonoBehaviour
{
    public GameObject fart;
    public GameObject spawnLocation;

    public float bearFartTimer=5;
    private float bearFartSpeed;




    // Start is called before the first frame update
    void Start()
    {
        bearFartTimer=5;
        setBearFartSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        bearFartTimer-=Time.deltaTime;

    }

    private void setBearFartSpeed()
    {
        bearFartSpeed=Random.Range(1F, bearFartTimer);
        Debug.Log(bearFartSpeed);
    }

    private void bearFart()
    {
        if(bearFartSpeed>=0)
        {
            fart.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearFartMinigameManager : MonoBehaviour
{
    public GameObject fart;
    public Transform asshole;

    public DoubleHandMovement dhm;

    public float bearFartTimer=5;
    private float bearFartSpeed;

    static private bool farted=false;



    // Start is called before the first frame update
    void Start()
    {
        bearFartTimer=5;
        farted = false;


        setBearFartSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        bearFartSpeed-=Time.deltaTime;
        if (bearFartSpeed < 0 && farted.Equals(false))
        {
            bearFart();
        }
        checkGameWin();
    }

    private void setBearFartSpeed()
    {
        bearFartSpeed=Random.Range(1F, bearFartTimer-1);
        Debug.Log(bearFartSpeed);
    }

    private void bearFart()
    {
        Instantiate(fart, asshole.position, transform.rotation);
        farted=true;
    }

    private void checkGameWin()
    {
        Debug.Log(dhm.getNoseCovered());
        if (farted.Equals(true) && bearFartSpeed > -0.5 && dhm.getNoseCovered().Equals(true))
        {
            GameManager.endMiniGame(true);
        }
        else if(farted.Equals(true) && bearFartSpeed<-0.5)
        {
            GameManager.endMiniGame(false);
        }
    }
}

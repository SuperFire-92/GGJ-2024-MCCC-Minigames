using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BearFartMinigameManager : MonoBehaviour
{
    public GameObject fart;
    public Transform asshole;

    public TMP_Text instructions;

    public DoubleHandMovement dhm;

    public float bearFartTimer=5;
    private float bearFartSpeed;

    private bool ended = false;

    static private bool noseCovered=false;
    static private bool farted=false;



    // Start is called before the first frame update
    void Start()
    {
        bearFartTimer=5;
        noseCovered = false;
        farted = false;
        ended = false;


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

        buttonChecker();
        checkGameWin();
    }

    private void buttonChecker()
    {
        //If space is clicked
        if (Input.GetKeyDown(KeyCode.Space))
        {
            noseCovered=true;
        }
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
        if(ended==false) 
        {
            if (farted.Equals(false) && noseCovered.Equals(true))
            {
                instructions.text = "SOMEONE doesn't like the local wildlife";
                ended = true;
                GameManager.endMiniGame(false);
            }
            if (farted.Equals(true) && bearFartSpeed > -0.5 && noseCovered.Equals(true))
            {
                instructions.text = "Flatulation escapation!";
                ended = true;
                GameManager.endMiniGame(true);
            }
            else if (farted.Equals(true) && bearFartSpeed < -0.5)
            {
                instructions.text = "He who smelt it dealt it";
                ended = true;
                GameManager.endMiniGame(false);
            }
        }

    }
}

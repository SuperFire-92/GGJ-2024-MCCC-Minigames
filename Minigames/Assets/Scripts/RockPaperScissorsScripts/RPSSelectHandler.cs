using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPSSelectHandler : MonoBehaviour
{

    private bool canClick;
    public GameObject RockPaperScissorsObject;
    private RPSControler RPSControlerScript;
    public int whoAmI;
    //  0 == rock
    //  1 == paper
    //  2 == scissors

    // Start is called before the first frame update
    void Start()
    {
        canClick = false;
        RPSControlerScript = RockPaperScissorsObject.GetComponent<RPSControler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && canClick)
        {
           
            RPSControlerScript.evaluateGame(whoAmI);

            
        }
    }

    private void OnMouseOver()
    {
        canClick = true;
    }

    private void OnMouseExit()
    {
        canClick = false;
    }

}

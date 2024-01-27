using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleRacerGoal : MonoBehaviour
{



    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag.Equals("Player"))
        {

            GameManager.endMiniGame(true);
        }
        else
        {
            GameManager.endMiniGame(false);

        }

    }


}

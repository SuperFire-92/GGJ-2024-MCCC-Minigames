using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    private static int points;

    // Update is called once per frame
    void Update()
    {
        if(points >= 2)
        {
            point();
        }
    }
    void point()
    {
        GameManager.endMiniGame(true);
    }
     public static int addpoint()
    {
        points++;
        return points;
    }
  

}

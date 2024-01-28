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
            removepoint();

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
    void removepoint()
    {
        points = 0;
    }
  

}

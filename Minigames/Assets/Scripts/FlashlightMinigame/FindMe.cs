using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindMe : MonoBehaviour
{
    float xMin = -8f;
    float xMax = 8f;
    float yMin = -4f;
    float yMax = 4f;


    // Spawns in FindMe at a random location
    void Start()
    {
        float x;
        float y;

        do
        {
            x = UnityEngine.Random.Range(xMin, xMax);
        } while (x > -2 && x < 2);

        do
        {
            y = UnityEngine.Random.Range(yMin, yMax);
        } while (y > -1.5 && y < 1.5);




        transform.position = new Vector2(x, y);
    }
}

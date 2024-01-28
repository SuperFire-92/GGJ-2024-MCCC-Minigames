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


        x = UnityEngine.Random.Range(xMin, xMax);


        y = UnityEngine.Random.Range(yMin, yMax);





        transform.position = new Vector2(x, y);
    }
}

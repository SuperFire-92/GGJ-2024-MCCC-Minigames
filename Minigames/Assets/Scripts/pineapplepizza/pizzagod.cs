using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pizzagod : MonoBehaviour
{
    public GameObject[] sliceObjects;
    private slice[] slices;
    public int consumerCount;
    public float timerDuration;
    private float timerStart;

    // Start is called before the first frame update
    void Start()
    {
        slices = new slice[sliceObjects.Length];
        for (int i = 0; i < sliceObjects.Length; ++i)
        {
            slices[i] = sliceObjects[i].GetComponent<slice>();
        }

        timerStart = -1;
    }

    // Update is called once per frame
    void Update()
    {
        int happyCount;

        happyCount = 0;
        for (int i = 0; i < slices.Length; ++i)
        {
            if (slices[i].isMakingHappiness)
            {
                ++happyCount;
            }
        }

        if (happyCount >= consumerCount)
        {
            //Start winning.
            if (timerStart == -1)
            {
                timerStart = Time.time;
            }
            
            if (timerStart + timerDuration >= Time.time)
            {
                //Win!
                GameManager.endMiniGame(true);
            }
        }
        else //Not winning.
        {
            timerStart = -1;
        }
    }
}
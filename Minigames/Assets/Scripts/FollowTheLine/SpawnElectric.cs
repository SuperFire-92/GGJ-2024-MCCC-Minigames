using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnElectric : MonoBehaviour
{
    public GameObject electricity;
    public float delay;
    private float maxDelay;
    private float minDelay; 

    private float xLength;
    private float yLength;

    private float curTime;

    void Start()
    {
        xLength = transform.localScale.x;
        yLength = transform.localScale.y;

        curTime = 0;

        maxDelay = delay;
        minDelay = delay - 0.1f;

        delay = Random.Range(minDelay, maxDelay);
    }


    void Update()
    {
        curTime += Time.deltaTime;
        if (curTime > delay)
        {
            // spawn in the thing

            GameObject newObj;
            newObj = Instantiate(electricity, this.transform);

            float randX = Random.Range(-xLength / 2, xLength / 2);
            float randY = Random.Range(-yLength / 2, yLength / 2);


            newObj.transform.Translate(new Vector2(randX, randY));

            // random delay so it looks less bad
            delay = Random.Range(minDelay, maxDelay);
            curTime = 0;
        }
    }
}

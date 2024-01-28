using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawnScript : MonoBehaviour
{
    public GameObject birdPrefab;
    public GameObject top;
    public GameObject bottom;
    public float timerDuration;
    
    private float timerStart;


    // Start is called before the first frame update
    void Start()
    {
        timerStart = Time.time - timerDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - timerStart > timerDuration)
        {
            GameObject bird;
            float topY;
            float bottomY;

            topY = top.transform.position.y;
            bottomY = bottom.transform.position.y;

            bird = Instantiate(birdPrefab);
            bird.transform.position = new Vector3(transform.position.x, Random.Range(bottomY, topY), transform.position.z);
            
            timerStart = Time.time;
        }
    }
}

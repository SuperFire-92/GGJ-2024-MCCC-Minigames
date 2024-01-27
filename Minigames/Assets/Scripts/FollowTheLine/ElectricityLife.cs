using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityLife : MonoBehaviour
{
    public float lifeTime;
    private float curTime;

    private void Start()
    {
        curTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;
        if (curTime > lifeTime)
        {
            Destroy(gameObject);
        }
    }


}

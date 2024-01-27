using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleRacerProgressBar : MonoBehaviour
{
    private float progress;

    // Start is called before the first frame update
    void Start()
    {
        progress = 0f;
    }

    public void setProgressBar(float p)
    {

        progress = p;

    }

    private void Update()
    {
        transform.localScale = new Vector3 (progress * 0.5f, 0.2f, 1f);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jackcontroller : MonoBehaviour
{
    private int count;
    private int progresscount;
    public GameObject jack1;
    public GameObject jack2;
    public GameObject jack3;
    public GameObject jack4;
    public GameObject progress;
    void Start()
    {
        progress.transform.localScale = new Vector3(0, .2f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        jack();
    }
    void jack()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            count++;
            progresscount++;
           progress.transform.localScale = new Vector3 (progresscount * .5f,(float).2,1);
            if(progress.transform.localScale == new Vector3(2.5f,.2f,1))
            {
                progress.transform.localScale = new Vector3 (0f,.2f,1);
                progresscount = 0;
            }
        }
        if(count == 5)
        {
            jack1.SetActive(true);
        }
        else if((count == 10))
        {
            jack2.SetActive(true);
        }
        else if(count == 15)
        {
            jack3.SetActive(true);
        }
        else if(count == 20)
        {
            jack4.SetActive(true);
            GameManager.endMiniGame(true);
        }
    }
}

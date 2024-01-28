using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jackcontroller : MonoBehaviour
{
    private int count;
    private int progresscount;
    public GameObject progress;
    private AudioSource audios;
    public GameObject handleUp;
    public GameObject handleDown;
    public GameObject jack;
    private bool canJack = true;

    void Start()
    {
        progress.transform.localScale = new Vector3(0, .2f, 1);
        audios = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        jackSpace();
    }
    void jackSpace()
    {
        if(Input.GetKeyDown(KeyCode.Space) && canJack)
        {
            audios.Play();
            count++;
            if (count % 2 == 0)
            {
                handleUp.SetActive(false);
                handleDown.SetActive(true);
            }
            else
            {
                handleUp.SetActive(true);
                handleDown.SetActive(false);
            }
            Debug.Log("count " + count);
            progresscount++;
           progress.transform.localScale = new Vector3 (progresscount * .5f,(float).2,1);
            if(progress.transform.localScale == new Vector3(2.5f,.2f,1))
            {
                progress.transform.localScale = new Vector3 (0f,.2f,1);
                progresscount = 0;
            }


            int goal = Random.Range(18, 26);
            if (count == goal)
            {
                canJack = false;
                jack.SetActive(true);
                GameManager.endMiniGame(true);
            }
        }
    }
}

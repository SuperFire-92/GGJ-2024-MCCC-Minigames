using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class consumergod : MonoBehaviour
{
    public float timerDuration;

    private float timerStart;
    private consumer[] consumers;


    // Start is called before the first frame update
    void Start()
    {
        int childCount;
        int pineappleLover;

        //Set overall rotation.
        transform.rotation = Quaternion.Euler(0.00f, 0.00f, Random.Range(-180.00f, 180.00f));

        childCount = transform.childCount;
        consumers = new consumer[childCount];

        pineappleLover = Random.Range(0, childCount);

        for (int i = 0; i < childCount; ++i)
        {
            consumers[i] = transform.GetChild(i).GetComponent<consumer>();

            //Correct child rotation.
            consumers[i].transform.rotation = Quaternion.Euler(Vector3.zero);

            //Set pineapple affinity.
            consumers[i].setLikesPineapple(i == pineappleLover);
        }

        timerStart = -1.00f;
    }

    void Update() {
        bool everyoneIsHappy;

        everyoneIsHappy = true;

        for (int i = 0; i < consumers.Length; ++i) {
            if (!consumers[i].isHappy) {
                everyoneIsHappy = false;
                break;
            }
        }

        if (everyoneIsHappy) {
            if (timerStart == -1.00f) {
                //Start winning.
                timerStart = Time.time;
                Debug.Log("Started winning.");

                Debug.Log(timerStart);
                Debug.Log(timerDuration);
                Debug.Log(Time.time);
            }

            if (timerStart + timerDuration >= Time.time) {
                //Win!
                GameManager.endMiniGame(true);
                Debug.Log("Win!");
            }

            Debug.Log("Currently winning. " + (timerDuration - (Time.time - timerStart)) + " seconds remaining.");
        }
        else {
            //Not winning. :(
            timerStart = -1.00f;
        }
    }
}

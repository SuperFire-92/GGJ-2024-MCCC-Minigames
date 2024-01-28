using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class FollowLineStartGame : MonoBehaviour
{
    public GameObject timer;
    public GameObject instructionText;
    public GameObject[] fooBar;

    private bool startGame;

    private float xMax;
    private float yMax;

    private float timeHovering;

    void Start()
    {
        startGame = false;

        xMax = Screen.width;
        yMax = Screen.height;

        timeHovering = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startGame) 
        {
            Vector3 mousePos = Input.mousePosition;

            mousePos.x /= xMax;
            mousePos.y /= yMax;

            mousePos = Camera.main.ViewportToWorldPoint(mousePos);
            mousePos.z = 0;

            float xMouseDist = transform.position.x - mousePos.x;
            float yMouseDist = transform.position.y - mousePos.y;

            if (xMouseDist < -0.5f || xMouseDist > 0.5f)
            {
                timeHovering = 0;
                return;
            }
            if (yMouseDist < -0.5f || yMouseDist > 0.5f)
            {
                timeHovering = 0;
                return;
            }

            timeHovering += Time.deltaTime;
            if (timeHovering > 1.5f)
            {
                startGame = true;
                timer.GetComponent<Timer>().startTimer();

                // get rid of instructions and spawn the bar
                instructionText.SetActive(false);

                fooBar[Random.Range(0, 1)].SetActive(true);
                //get rid of the dot
                gameObject.SetActive(false);
            }

        }


    }
}

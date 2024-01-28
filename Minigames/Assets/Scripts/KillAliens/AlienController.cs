using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AlienController : MonoBehaviour
{
    private Vector3 startPos;

    public float speed; //5
    public float xScale; //1
    public float yScale; //0.5

    private int numOfAliensInScene;
    private int currentNum;

    [SerializeField] AudioSource hitSound;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        GameObject[] num = GameObject.FindGameObjectsWithTag("alien");
        currentNum = num.Length;
    }

    // Update is called once per frame
    void Update()
    {
        moveAlien();
        checkForAliens();
    }

    private void moveAlien()
    {
        transform.position = startPos + (Vector3.right * Mathf.Sin(Time.timeSinceLevelLoad / 2 * speed) * xScale - Vector3.up * Mathf.Sin(Time.timeSinceLevelLoad * speed) * yScale);
    }

    private void OnMouseOver()
    {
        Debug.Log("hovering");
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Debug.Log("clicked");

            //Check if there are aliens left (== 1 and not null because this alien isn't destroyed yet). If not, win
            GameObject[] aliensInScene;
            aliensInScene = GameObject.FindGameObjectsWithTag("alien");
            if (aliensInScene.Length == 1)
            {
                Debug.Log("WIN");
                //WIN CONDITION HERE
                GameManager.endMiniGame(true);
            }

            Destroy(this.gameObject);
        }
    }

    private void checkForAliens() //I have to do all this just to make sound effects work but whatever
    {
        GameObject[] aliensInScene = GameObject.FindGameObjectsWithTag("alien");
        numOfAliensInScene = aliensInScene.Length;

        if (numOfAliensInScene != currentNum)
        {
            currentNum = numOfAliensInScene;
            hitSound.Play();
        }
    }
}

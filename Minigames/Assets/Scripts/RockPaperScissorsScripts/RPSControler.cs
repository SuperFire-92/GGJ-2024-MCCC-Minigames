using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RPSControler : MonoBehaviour
{

    public GameObject[] RPSList;
    public GameObject spawnLocation;
    private GameObject currentMove;
    private Rigidbody2D currentMoveRigidbody2D;
    private int chosenMove;
    private Vector3 randomRotation;
    //  0 = rock
    //  1 = paper
    //  2 = scissors

    // Start is called before the first frame update
    void Start()
    {
        chosenMove = Random.Range(0, 3);
        currentMove = Instantiate(RPSList[chosenMove]);
        currentMoveRigidbody2D = currentMove.GetComponent<Rigidbody2D>();
        currentMove.transform.position = spawnLocation.transform.position;
        currentMoveRigidbody2D.velocity = new Vector3(10, 1.3f, 0);
        randomRotation = new Vector3(0, 0, -Random.Range(90, 180) * Time.deltaTime);
        
        

        
    }

    // Update is called once per frame
    void Update()
    {
     
        
        currentMove.transform.Rotate(randomRotation);

        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene("RockPaperScissors");
        }

    }

    public int getCorrectMove()
    {
        return chosenMove;
    }

    public void evaluateGame(int c)
    {

        //  0 = rock
        //  1 = paper
        //  2 = scissors

        //Debug.Log("Nums = " + c + " , " + chosenMove);

        if (c == chosenMove)
        {

        }
        else
        {

            if (c == 0 && chosenMove == 2)
            {

                GameManager.endMiniGame(true);

            }
            else if (c == 0)
            {

                GameManager.endMiniGame(false);

            }
            else if (c == 1 && chosenMove == 0)
            {
 
                GameManager.endMiniGame(true);

            }
            else if (c == 1)
            {

                GameManager.endMiniGame(false);

            }
            else if (c == 2 && chosenMove == 1)
            {

                GameManager.endMiniGame(true);

            }
            else
            {

                GameManager.endMiniGame(false);

            }
        }

    }

   
}

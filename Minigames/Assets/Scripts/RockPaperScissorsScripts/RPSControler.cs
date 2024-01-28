using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RPSControler : MonoBehaviour
{

    public GameObject[] RPSList;
    public GameObject spawnLocation;
    private GameObject currentMove;
    private Rigidbody2D currentMoveRigidbody2D;
    private int chosenMove;
    private bool choseCorrect;
    private Vector3 randomRotation;
    private AudioSource audioSourceControl;
    public AudioClip gameStart;
    public AudioClip correctSound;
    public AudioClip WrongAnswer;
    //  0 = rock
    //  1 = paper
    //  2 = scissors

    // Start is called before the first frame update
    void Start()
    {
        audioSourceControl = GetComponent<AudioSource>();
        audioSourceControl.Play();
        choseCorrect = false;

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
        audioSourceControl.clip = WrongAnswer;
        
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
                choseCorrect = true;
            }
            else if (c == 0)
            {
                choseCorrect = false;
            }
            else if (c == 1 && chosenMove == 0)
            {
                choseCorrect = true;
            }
            else if (c == 1)
            {
                choseCorrect = false;
            }
            else if (c == 2 && chosenMove == 1)
            {
                choseCorrect = true;
            }
            else
            {
                choseCorrect = false;
            }

            if (choseCorrect)
            {
                audioSourceControl.clip = correctSound;
            }
            else
            {
                audioSourceControl.clip = WrongAnswer;
            }

            audioSourceControl.Play();

            if (choseCorrect)
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienHitSounds : MonoBehaviour
{
    private int numOfAliensInScene;
    private int currentNum;

    [SerializeField] AudioSource hitSound;

    // Start is called before the first frame update
    void Start()
    {
        currentNum = numOfAliensInScene;
    }

    // Update is called once per frame
    void Update()
    {
        checkForAliens();
    }

    private void checkForAliens()
    {
        GameObject[] aliensInScene = GameObject.FindGameObjectsWithTag("alien");
        numOfAliensInScene = aliensInScene.Length;

        if (numOfAliensInScene != currentNum)
        {
            currentNum = numOfAliensInScene;
            Debug.Log("here");
            hitSound.Play();
        }
    }
}

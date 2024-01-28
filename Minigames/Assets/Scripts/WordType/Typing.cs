using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Windows;

public class Typing : MonoBehaviour
{
    public TextMeshProUGUI wordText;
    public TextMeshProUGUI mistakesText;
    public TextMeshProUGUI wordsLeftText;
    public int numOfWordsToType;
    public int mistakesAllowed;
    private int mistakes = 0;
    private List<string> words = new List<string>();
    private string word;

    [SerializeField] AudioSource correctSound;
    [SerializeField] AudioSource wrongSound;
    [SerializeField] AudioSource typeSound;

    private string fileName = Application.dataPath + "/Scripts/WordType/dictionary.txt";

    // Start is called before the first frame update
    void Start()
    {
        pickWord();
        wordsLeftText.SetText("Words Left: " + numOfWordsToType);
        numOfWordsToType--;

        mistakesText.SetText("Mistakes Left: " + (mistakesAllowed - mistakes));
        mistakesText.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        getInput();
        check();
    }

    private void getInput()
    {
        if (UnityEngine.Input.anyKeyDown)
        {
            //Debug.Log(Input.inputString);
            checkIfRight(UnityEngine.Input.inputString);
        }
    }

    private void checkIfRight(string i)
    {


        if (word.Length > 0)
        {
            char input = i[0];

            if (input == word[0])
            {
                typeSound.Play();
                word = word.Substring(1);
                wordText.SetText(word);
            }
            else
            {
                wrongSound.Play();
                mistakes++;
                mistakesText.SetText("Mistakes Left: " + (mistakesAllowed - mistakes));

                float percentAsFloat = ((float)mistakes/(float)mistakesAllowed);
                Debug.Log("percent of mistakes made: " + percentAsFloat.ToString());

                //Percent of mistakes made of total allowed mistakes determines the color of mistakes text
                if (percentAsFloat < 0.66f && percentAsFloat > 0.32f)
                {
                    mistakesText.color = Color.yellow;
                }
                else if (percentAsFloat > 0.65f)
                {
                    mistakesText.color = Color.red;
                }

                if (mistakes >= mistakesAllowed)
                {
                    //LOSE CONDITION
                    Debug.Log("LOSE");
                    GameManager.endMiniGame(false);
                }
            }
        }
    }

    private void check()
    {
        if (word.Length == 0)
        {
            if (numOfWordsToType == 0)
            {
                wordsLeftText.SetText("Words Left: 0");
                correctSound.Play();
                //WIN CONDITION
                Debug.Log("WIN");
                GameManager.endMiniGame(true);
            }
            else
            {
                correctSound.Play();
                wordsLeftText.SetText("Words Left: " + numOfWordsToType);
                numOfWordsToType--;
                //Show another word
                pickWord();
            }
        }
    }

    private void pickWord()
    {
        int line = UnityEngine.Random.Range(1, 370100);
        using (var sr = new StreamReader(fileName))
        {
            for (int i = 1; i < line; i++)
            {
                word = sr.ReadLine();
            }
        }
        wordText.SetText(word);
    }
}

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
    private string word;
    private List<string> words;

    [SerializeField] AudioSource correctSound;
    [SerializeField] AudioSource wrongSound;
    [SerializeField] AudioSource typeSound;

    //unfortunately dictionary doesn't work
    //private string fileName = Application.dataPath + "/Scripts/WordType/dictionary.txt";

    // Start is called before the first frame update
    void Start()
    {
        words = new List<string>();
        initWords();
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
        int randomIndex = UnityEngine.Random.Range(0, words.Count);
        word = words[randomIndex];
        wordText.SetText(word);


        //RIP DICTIONARY :(
        //int line = UnityEngine.Random.Range(1, 370100);
        //using (var sr = new StreamReader(fileName))
        //{
        //    for (int i = 1; i < line; i++)
        //    {
        //        word = sr.ReadLine();
        //    }
        //}
        //wordText.SetText(word);
    }

    private void initWords()
    {
        words.Add("junkware");
        words.Add("versed");
        words.Add("flavor");
        words.Add("create");
        words.Add("plain");
        words.Add("scowl");
        words.Add("laughable");
        words.Add("parched");
        words.Add("dash");
        words.Add("press");
        words.Add("mountain");
        words.Add("spoon");
        words.Add("understand");
        words.Add("freezing");
        words.Add("swing");
        words.Add("quicksand");
        words.Add("crayon");
        words.Add("tested");
        words.Add("scale");
        words.Add("alight");
        words.Add("workable");
        words.Add("learn");
        words.Add("motionless");
        words.Add("take");
        words.Add("fucks");
        words.Add("achiever");
        words.Add("actually");
        words.Add("apperently");
        words.Add("everything");
        words.Add("usually");
        words.Add("fine");
        words.Add("dedicate");
        words.Add("heart");
        words.Add("optimize");
        words.Add("disguest");
        words.Add("graceful");
        words.Add("graceful");
        words.Add("consider");
        words.Add("inspire");
        words.Add("coat");
        words.Add("tense");
        words.Add("smart");
        words.Add("hustel");
        words.Add("vagabond");
        words.Add("feeling");
        words.Add("ants");
        words.Add("wacky");
        words.Add("yoke");
        words.Add("ultra");
        words.Add("minecraft");
        words.Add("uttermost");
        words.Add("automatic");
        words.Add("stretch");
        words.Add("calculate");
        words.Add("linen");
        words.Add("impel");
        words.Add("political");
        words.Add("astonish");
        words.Add("contend");
        words.Add("awake");
        words.Add("omit");
        words.Add("toad");
        words.Add("rebel");
        words.Add("drawer");
        words.Add("aromatic");
        words.Add("faint");
        words.Add("translate");
        words.Add("perish");
        words.Add("window");
        words.Add("trucks");
        words.Add("chew");
        words.Add("charge");
        words.Add("stare");
        words.Add("aboard");
        words.Add("wanting");
        words.Add("zoom");
        words.Add("temper");
        words.Add("defective");
        words.Add("wring");
        words.Add("celery");
        words.Add("beat");
        words.Add("tense");
        words.Add("fan");
        words.Add("proceed");
        words.Add("minecraft");
        words.Add("fortnite");
        words.Add("untidy");
        words.Add("handsomely");
        words.Add("enchanted");
        words.Add("parsnip");
        words.Add("stocking");
        words.Add("frightening");
        words.Add("grotesque");
        words.Add("manager");
        words.Add("harmonious");
        words.Add("ache");
        words.Add("squealing");
        words.Add("hysterical");
        words.Add("symptomatic");
        words.Add("redundant");
        words.Add("diligence");
        words.Add("innocent");
        words.Add("domineering");
        words.Add("dominant");
        words.Add("recessive");
        words.Add("president");
        words.Add("governor");
        words.Add("basketball");
        words.Add("baseball");
        words.Add("football");
        words.Add("accompany");
    }
}

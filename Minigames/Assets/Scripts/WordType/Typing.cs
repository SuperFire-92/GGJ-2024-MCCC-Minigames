using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Typing : MonoBehaviour
{
    public TextMeshProUGUI wordText;
    public TextMeshProUGUI mistakesText;
    public int numOfWordsToType;
    public int mistakesAllowed;
    private int mistakes = 0;
    private List<string> words = new List<string>();
    private string word;

    // Start is called before the first frame update
    void Start()
    {
        initializeWords();
        int randomIndex = UnityEngine.Random.Range(0, words.Count - 1);
        wordText.SetText(words[randomIndex]);
        word = words[randomIndex];
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
        if (Input.anyKeyDown)
        {
            //Debug.Log(Input.inputString);
            checkIfRight(Input.inputString);
        }
    }

    private void checkIfRight(string i)
    {
        char input = i[0];

        if (word.Length > 0)
        {
            if (input == word[0])
            {
                word = word.Substring(1);
                wordText.SetText(word);
            }
            else
            {
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
                //WIN CONDITION
                Debug.Log("WIN");
                GameManager.endMiniGame(true);
            }

            numOfWordsToType--;
            //Show another word
            int randomIndex = UnityEngine.Random.Range(0, words.Count - 1);
            wordText.SetText(words[randomIndex]);
            word = words[randomIndex];
        }
    }

    private void initializeWords()
    {
        //Just a couple words
        words.Add("absolutely");
        words.Add("especially");
        words.Add("incredibly");
        words.Add("understand");
        words.Add("appreciate");
        words.Add("compliment");
        words.Add("accelerate");
        words.Add("jaywalking");
        words.Add("lumberjack");
        words.Add("maximizing");
        words.Add("minimizing");
        words.Add("jackhammer");
        words.Add("journaling");
        words.Add("subjective");
        words.Add("dehumanize");
        words.Add("strawberry");
        words.Add("pineapples");
        words.Add("friendship");
        words.Add("everything");
        words.Add("motivation");
        words.Add("pens");
        words.Add("brother");
        words.Add("brain");
        words.Add("self");
        words.Add("guitar");
        words.Add("tolerate");
        words.Add("resign");
        words.Add("eject");
        words.Add("doubt");
        words.Add("reduce");
        words.Add("lobby");
        words.Add("stem");
        words.Add("global");
        words.Add("entertain");
        words.Add("surprise");
        words.Add("recipe");
        words.Add("ready");
        words.Add("shatter");
        words.Add("ice");
        words.Add("album");
        words.Add("mountain");
        words.Add("queen");
        words.Add("king");
        words.Add("prince");
        words.Add("church");
        words.Add("well");
        words.Add("round");
        words.Add("polite");
        words.Add("convince");
        words.Add("host");
        words.Add("ride");
        words.Add("relevant");
        words.Add("side");
        words.Add("pain");
        words.Add("sleep");
        words.Add("tray");
        words.Add("lunch");
        words.Add("sense");
        words.Add("accept");
        words.Add("temple");
        words.Add("favor");
        words.Add("spot");
        words.Add("contribute");
        words.Add("sun");
        words.Add("dog");
        words.Add("cat");
        words.Add("cherry");
        words.Add("grape");
        words.Add("brown");
        words.Add("green");
        words.Add("red");
        words.Add("blue");
        words.Add("pluck");
        words.Add("locate");
        words.Add("global");
        words.Add("youg");
        words.Add("partner");
        words.Add("debut");
        words.Add("minecraft");
        words.Add("creeper");
        words.Add("zombie");
        words.Add("steve");
        words.Add("enderman");
        words.Add("mother");
        words.Add("minecraft");
        words.Add("minecraft");
        words.Add("minecraft");
        words.Add("minecraft");
    }
}

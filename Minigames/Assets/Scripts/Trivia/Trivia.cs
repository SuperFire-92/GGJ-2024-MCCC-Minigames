using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Trivia : MonoBehaviour
{
    public TextMeshProUGUI ansAText;
    public TextMeshProUGUI ansBText;
    public TextMeshProUGUI ansCText;
    public TextMeshProUGUI ansDText;
    public TextMeshProUGUI promptText;

    private List<PromptAndAnswer> list = new List<PromptAndAnswer>();
    private PromptAndAnswer current;
    private string prompt;
    private string A;
    private string B;
    private string C;
    private string D;
    private string correctAnswer;

    [SerializeField] AudioSource correctNoise;
    [SerializeField] AudioSource wrongNoise;

    // Start is called before the first frame update
    void Start()
    {
        initializeList();
        int randomIndex = Random.Range(0, list.Count);
        current = list[randomIndex];
        ansAText.SetText(current.getAnsA());
        ansBText.SetText(current.getAnsB());
        ansCText.SetText(current.getAnsC());
        ansDText.SetText(current.getAnsD());
        promptText.SetText(current.getPrompt());
        correctAnswer = current.getCorrectAns();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void btnA()
    {
        Debug.Log("Button A Clicked");
        if (correctAnswer == "A")
        {
            winGame();
        }
        else
        {
            loseGame();
        }
    }

    public void btnB()
    {
        Debug.Log("Button B Clicked");
        if (correctAnswer == "B")
        {
            winGame();
        }
        else
        {
            loseGame();
        }
    }

    public void btnC()
    {
        Debug.Log("Button C Clicked");
        if (correctAnswer == "C")
        {
            winGame();
        }
        else
        {
            loseGame();
        }
    }

    public void btnD()
    {
        Debug.Log("Button D Clicked");
        if (correctAnswer == "D")
        {
            winGame();
        }
        else
        {
            loseGame();
        }
    }

    private void winGame()
    {
        //WIN CONDITION
        Debug.Log("WIN");
        correctNoise.Play();
        GameManager.endMiniGame(true);
    }

    private void loseGame()
    {
        //LOSE CONDITION
        Debug.Log("LOSE");
        wrongNoise.Play();
        GameManager.endMiniGame(false);
    }

    private void initializeList()
    {
        list.Add(new PromptAndAnswer("What's Obama's last name", "Barack", "No one knows", "Jackson", "Haywood", "B"));
        list.Add(new PromptAndAnswer("How do you spell 'church'?", "church", "chruch", "churhc", "hcurch", "A"));
        list.Add(new PromptAndAnswer("What does 'supercalifragilisticexpialidocious' mean?", "Wonderful", "Super", "Bad", "It isn't a word", "A"));
        list.Add(new PromptAndAnswer("What animal did Australian soldiers fight in 1932?", "Cats", "Chickens", "Emus", "Your Mother", "C"));
        list.Add(new PromptAndAnswer("Why did the chicken cross the road?", "To get to the idiot's house", "To get to the other side", "It didn't", "All of the above", "D"));
        list.Add(new PromptAndAnswer("Why is it called a vacuum?", "It is shaped like a V", "It isn't", "I don't know", "It sucks", "D"));
        list.Add(new PromptAndAnswer("How long did the 100 years war last?", "100 years", "116 years", "90 years", "1 day", "B"));
        list.Add(new PromptAndAnswer("What do you call a fish with no eyes?", "Fsh", "A fish", "Fishstick", "None of the above", "A"));
        list.Add(new PromptAndAnswer("What is this game based off of?", "It's a totally original idea", "WarioWare", "Minecraft", "Fortnite", "B"));

        //Finds 3 random numbers (that aren't the user's current score). Once answer (C) will be the correct answer, displaying the user's current score
        int a = 0;
        while (a == GameManager.getScore())
        {
            a = Random.Range(0, 36);
        }
        int b = 0;
        while (b == GameManager.getScore())
        {
            b = Random.Range(0, 36);
        }
        int d = 0;
        while (d == GameManager.getScore())
        {
            d = Random.Range(0, 36);
        }
        list.Add(new PromptAndAnswer("What is your current score?", a.ToString(), b.ToString(), GameManager.getScore().ToString(), d.ToString(), "C"));
    }
}

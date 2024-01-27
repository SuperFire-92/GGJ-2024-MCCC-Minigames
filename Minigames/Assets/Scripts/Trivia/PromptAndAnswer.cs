using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptAndAnswer
{
    private string prompt;
    private string ansA;
    private string ansB;
    private string ansC;
    private string ansD;
    private string correctAns;

    public PromptAndAnswer(string p, string a, string b, string c, string d, string ca)
    {
        prompt = p;
        ansA = a;
        ansB = b;
        ansC = c;
        ansD = d;
        correctAns = ca;
    }

    public string getPrompt()
    {
        return prompt;
    }

    public string getAnsA()
    {
        return ansA;
    }

    public string getAnsB()
    {
        return ansB;
    }

    public string getAnsC()
    {
        return ansC;
    }

    public string getAnsD()
    {
        return ansD;
    }

    public string getCorrectAns()
    {
        return correctAns;
    }
}

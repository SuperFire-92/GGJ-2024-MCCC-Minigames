using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameBouncer : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private TextMeshProUGUI instructions;

    private float timer;
    private Level selectedLVL;

    private void Start()
    {
        //Set the score text to the current score

        timer = 3f;
        selectedLVL = LevelList.getRandomLevel();
        GameManager.instruction = selectedLVL.instruction;
        GameManager.uniqueMenu = selectedLVL.uniqueMenu;

        //set text
        instructions.text = selectedLVL.instruction;
        score.text = GameManager.getScore().ToString();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SceneManager.LoadScene(selectedLVL.sceneName);
        }else if (timer <= 1.25f)
        {

        }
    }
}

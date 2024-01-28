using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameBouncer : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI score;

    private float timer;
    private string gameName;

    private void Start()
    {
        //Set the score text to the current score
        score.text = GameManager.getScore().ToString();
        timer = 3f;
        gameName = LevelList.getRandomLevel();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SceneManager.LoadScene(gameName);
        }
    }
}

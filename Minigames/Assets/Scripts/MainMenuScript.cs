using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] AudioSource gameStartSound;
    private bool startTimer = false;
    float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        if (startTimer)
        {
            timer += Time.deltaTime;
        }
        if (timer >= 1)
        {
            SceneManager.LoadScene("TheGame");
        }
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void startGame()
    {
        gameStartSound.Play();

        startTimer = true;
    }
}

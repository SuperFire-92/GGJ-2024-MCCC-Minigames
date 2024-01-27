using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    //[SerializeField] AudioSource gameStartNoise;
    private AudioSource gameStartNoise;

    // Start is called before the first frame update
    void Start()
    {
        gameStartNoise = GetComponent<AudioSource>();
    }
    public void quitGame()
    {
        Application.Quit();
    }

    public void startGame()
    {
        gameStartNoise.Play();
        SceneManager.LoadScene("TheGame");
    }
}

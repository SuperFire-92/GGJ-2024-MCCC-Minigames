using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class LifeVisualController : MonoBehaviour
{
    //Sprites go from more full to less full
    public Sprite[] cushionsSprite;
    // Start of array is the first cushion that will deflate
    public GameObject[] cushionObj;

    public AudioClip[] passFailSounds;

    private AudioSource cushionAudioSource;
    private int curLives;
    private static int previousLives = 5;
    int deflateState;
    private float curTime;

    private const int totalLives = 5;
    private int deflatePrev;

    // for previously lost lives
    private int i_cushionToDeflate;

    private bool playedSound;

    private static int timesLoaded = 0;

    void Start()
    {
        cushionAudioSource = GetComponent<AudioSource>();
        curLives = GameManager.getLives();
        deflateState = 0;
        curTime = 0f;
        playedSound = false;


        deflatePrev = totalLives - previousLives;

        for (int i = 0; i < deflatePrev; i++) {
            // set all the lives previously lost to the deflated sprite
            
            cushionObj[i].GetComponent<UnityEngine.UI.Image>().sprite = cushionsSprite[cushionsSprite.Length - 1];
        }

        if (curLives < previousLives) {
            // (5 totalLives - 4 curLives - 1) = cushionObj[0]
            // (5 - 3 - 1) = cushionObj[1] 
            // we need to -1 to get the correct array pos
            i_cushionToDeflate = totalLives - curLives - 1;

            // put fail sound in
            cushionAudioSource.clip = passFailSounds[1];
        } else {
            // put the pass sound in
            cushionAudioSource.clip = passFailSounds[0];
            i_cushionToDeflate = -1;
        }

        timesLoaded++;
    }

    void Update()
    {
        curTime += Time.deltaTime;
        
        // cushion deflates every 0.2 seconds
        if (curTime > 0.2f && i_cushionToDeflate != -1) {

            // return if we are already at last element in our sprite array
            if (deflateState == cushionsSprite.Length - 1) {
                curTime = -999f;

                if (curLives == 0) {
                    GameManager.resetGame();
                    SceneManager.LoadScene("MainMenu");
                }

                return;
            }

            // play the sound ounce
            if (!playedSound) {
                cushionAudioSource.Play();
                playedSound = true;

                // set the previous lives to our current lives
                // it
                previousLives = curLives;
            }

            // deflate cushion
            cushionObj[i_cushionToDeflate].GetComponent<UnityEngine.UI.Image>().sprite = cushionsSprite[deflateState];
            deflateState++;

            // reset timer 
            curTime = 0f;
        }
        else if(i_cushionToDeflate == -1) 
        {
            // don't play the win sound if its your first time seeing the transition screen
            if (!playedSound && timesLoaded > 1) 
            {
                cushionAudioSource.Play();
                playedSound = true;
            }
        }
    }

    
}

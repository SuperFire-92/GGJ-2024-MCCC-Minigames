using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleRacerGoal : MonoBehaviour
{
    private AudioSource goalAudioSource;

    private void Start()
    {
      goalAudioSource = GetComponent<AudioSource>();

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag.Equals("Player"))
        {
            goalAudioSource.Play();
            GameManager.endMiniGame(true);
            
        }
        else
        {
            GameManager.endMiniGame(false);

        }

    }


}

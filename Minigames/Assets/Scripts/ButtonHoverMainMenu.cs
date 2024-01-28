using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHoverMainMenu : MonoBehaviour
{
    private AudioSource hoverSound;

    // Start is called before the first frame update
    void Start()
    {
        hoverSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playHoverSound()
    {
        hoverSound.Play();
    }
}

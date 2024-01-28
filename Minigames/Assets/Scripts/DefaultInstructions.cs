using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DefaultInstructions : MonoBehaviour
{
    TextMeshProUGUI instructions;

    void Start()
    {
        instructions = GetComponent<TextMeshProUGUI>();
        if (GameManager.instruction != null)
        {
            instructions.text = GameManager.instruction;
        }

        // disable the animation that makes the text go away
        if (GameManager.uniqueMenu)
        {
            this.gameObject.GetComponent<Animator>().enabled = false;
        }
    }

    // The animation is 'DefaultDuringGameText'
    // change it however you see fit
}

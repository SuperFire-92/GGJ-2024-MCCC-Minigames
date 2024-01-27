using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleHandMovement : MonoBehaviour
{
    public float movementSpeed;
    public float endPosY;
    private bool noseCovered;

    // Start is called before the first frame update
    void Start()
    {
        noseCovered = false;
    }

    // Update is called once per frame
    void Update()
    {
        buttonChecker();
    }

    //Puts the hands up when pressed
    private void buttonChecker()
    {
        //If space is clicked
        if (Input.GetKeyDown(KeyCode.Space))
        {
            coverNose();
        }
    }

    private void coverNose()
    {
        while(transform.position.y < endPosY) 
        {
            transform.Translate(Vector2.up * movementSpeed * Time.deltaTime);
            noseCovered=true;
        }
    }

    public bool getNoseCovered()
    {
        return noseCovered;
    }
}

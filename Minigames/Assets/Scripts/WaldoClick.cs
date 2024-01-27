using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaldoClick : MonoBehaviour
{
    private Transform myTransform;
    private SpriteRenderer myRenderer;
    private bool canClick = false;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = GetComponent<Transform>();
        myRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && canClick)
        {
            Debug.Log("CLICKED WALDO");
            //NEXT LEVEL or something idk
        }
    }

    private void OnMouseOver()
    {
        myRenderer.color = Color.gray;
        canClick = true;
    }

    private void OnMouseExit()
    {
        myRenderer.color = Color.white;
        canClick= false;
    }
}

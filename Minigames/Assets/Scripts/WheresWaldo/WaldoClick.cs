using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaldoClick : MonoBehaviour
{
    private SpriteRenderer myRenderer;
    private bool canClick = false;

    [SerializeField] AudioSource clickSound;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && canClick)
        {
            clickSound.Play();
            GameManager.endMiniGame(true);
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

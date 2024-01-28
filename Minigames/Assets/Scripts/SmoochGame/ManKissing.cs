using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManKissing : MonoBehaviour
{
    [SerializeField] private AudioSource smooch;
    [SerializeField] private AudioSource scream;
    [SerializeField] private GameObject kissCollider;
    [SerializeField] private GameObject killCollider;
    [SerializeField] private GameObject startButton;

    private int xMax;
    private int yMax;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        xMax = Screen.width;
        yMax = Screen.height;
    }

    void Update()
    {
        if (startButton.GetComponent<HoverButton>().gameStarted == true)
        {
            bool kiss = kissCollider.GetComponent<ColliderWin>().hasCollided, kill = killCollider.GetComponent<ColliderKill>().hasCollided;
            if (!(kiss == true || kill == true))
            {
                followMouse();
            }
            else
            {
                if (kiss)
                {
                    if (smooch.isPlaying == false)
                    {
                        smooch.Play();
                    }
                
                }
                else if (kill)
                {
                    if (scream.isPlaying == false)
                    {
                        scream.Play();
                    }
                
                }
            }
        }

        
    }
    private void followMouse()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos.x /= xMax;
        mousePos.y /= yMax;

        mousePos = Camera.main.ViewportToWorldPoint(mousePos);
        mousePos.z = 0;

        rb.MovePosition(mousePos);
    }
}

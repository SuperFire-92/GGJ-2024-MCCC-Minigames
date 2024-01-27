using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleRacerControler : MonoBehaviour
{

    private Rigidbody2D turtleRacerRigidbody2d;
    public TurtleRacerProgressBar progressBar;
    private SpriteRenderer turtleRacerSpriteRenderer;
    public Sprite turtleRacerSprite;
    public Sprite turtleRacerSprite2;
    public Sprite turtleRacerStoppedSprite;
    public bool launch;
    public float thrust;

    

    // Start is called before the first frame update
    void Start()
    {
        turtleRacerRigidbody2d = GetComponent<Rigidbody2D>();
        turtleRacerSpriteRenderer = GetComponent<SpriteRenderer>();
        turtleRacerSpriteRenderer.sprite = turtleRacerStoppedSprite;
        launch = false;


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            if (thrust < 10)
            {
                thrust += 1;


            }
            
        }


        if (thrust < 10 && thrust > 0)
        {
            thrust -= 0.5f * Time.deltaTime;
        }
        else if (thrust > 10)
        {
            thrust = 10;
        }
        else if (thrust < 0 )
        {
            thrust = 0;
            turtleRacerSpriteRenderer.sprite = turtleRacerStoppedSprite;


        }

        progressBar.setProgressBar(thrust);

        if (thrust >= 10 && !launch) 
        {
            launchTurtleRacer();

        }

        if (launch) 
        {
            if (turtleRacerRigidbody2d.velocity.x < 30)
            {
                turtleRacerRigidbody2d.velocity = new Vector3((turtleRacerRigidbody2d.velocity.x + 0.025f) * 1.001f, 0f, 0f);
            }
           
        }
    }


    public void launchTurtleRacer()
    {
        launch = true;
        turtleRacerSpriteRenderer.sprite = turtleRacerSprite;

    }

}

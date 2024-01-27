using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    private int points;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(points >= 2)
        {
            point();
        }
    }
    void point()
    {
        GameManager.endMiniGame(true);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            GameManager.endMiniGame(false);
            Debug.Log("the wall");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Endpoint"))
        {
            points++;
            Destroy(collision.gameObject);
        }
    }

}

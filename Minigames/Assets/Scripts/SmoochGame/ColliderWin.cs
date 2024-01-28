using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderWin : MonoBehaviour
{
    public bool hasCollided;

    private void Start()
    {
        hasCollided = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TRIGGER");
        if (collision.CompareTag("Win"))
        {
            GameManager.endMiniGame(true);
            hasCollided = true;
        }
    }
}

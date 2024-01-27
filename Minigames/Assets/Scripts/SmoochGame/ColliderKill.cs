using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderKill : MonoBehaviour
{
    public bool hasCollided;

    private void Start()
    {
        hasCollided = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TRIGGER");
        if (collision.CompareTag("Death"))
        {
            GameManager.endMiniGame(false);
            hasCollided = true;
        }
    }
}

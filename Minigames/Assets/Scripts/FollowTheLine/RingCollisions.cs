using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingCollisions : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameManager.endMiniGame(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.endMiniGame(true);
    }
}

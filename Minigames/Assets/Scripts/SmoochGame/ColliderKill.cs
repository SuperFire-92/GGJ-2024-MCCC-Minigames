using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderKill : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TRIGGER");
        if (collision.CompareTag("Death"))
        {
            GameManager.endMiniGame(false);
        }
    }
}

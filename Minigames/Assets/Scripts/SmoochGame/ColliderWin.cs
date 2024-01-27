using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderWin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TRIGGER");
        if (collision.CompareTag("Win"))
        {
            GameManager.endMiniGame(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slice : MonoBehaviour
{
    public bool isPineapple;
    [System.NonSerialized] public bool isMakingHappiness;

    void OnTriggerEnter2D(Collider2D collision)
    {
        isMakingHappiness = collision.gameObject.GetComponent<consumer>().getHappy(isPineapple);
    }
}

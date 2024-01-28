using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class consumer : MonoBehaviour
{
    public Sprite happy;
    public Sprite sad;

    private SpriteRenderer sr;
    private bool likesPineapple;


    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        likesPineapple = Random.Range(0, 2) == 0;
    }

    public bool getHappy(bool givenPineapple)
    {
        bool isHappy;

        isHappy = (likesPineapple && givenPineapple) || (!likesPineapple && !givenPineapple);

        sr.sprite = isHappy ? happy : sad;

        return isHappy;
    }
}

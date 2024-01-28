using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class consumer : MonoBehaviour
{
    public Sprite happy;
    public Sprite sad;

    [System.NonSerialized] public bool isHappy;

    private SpriteRenderer sr;
    //[SerializeField]
    private bool likesPineapple;


    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void updatePicture() {
        sr.sprite = isHappy ? happy : sad;
    }

    public void setLikesPineapple(bool shouldLikePineapple) {
        likesPineapple = shouldLikePineapple;
        updatePicture();
    }

    void OnTriggerEnter2D(Collider2D collision) {
        //Enter pineapple zone.
        isHappy = likesPineapple;
        updatePicture();
    }

    void OnTriggerExit2D(Collider2D collision) {
        //Exit pineapple zone.
        isHappy = !likesPineapple;
        updatePicture();
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PipeMovementScript : MonoBehaviour
{
    public Text test;
    public int Score;
    private Rigidbody2D rb;
    public float speed = 10f;
    private bool outOfBounds = false;
    [SerializeField] private TMP_Text score;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveVertical();
    }
    void moveVertical()
    {
        float input;

        input = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector3(0, input * speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        Destroy(collision.gameObject);
        Score++;
        score.SetText(Score + "/3");
        if (Score > 2) 
        {
            GameManager.endMiniGame(true);
        }
    }
}

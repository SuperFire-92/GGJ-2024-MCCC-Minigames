using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class surferMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public GameObject thingIWantToMake;

    // Start is called before the first frame update
    void Start()
    {
        GameObject test;
        rb = GetComponent<Rigidbody2D>();
        test = Instantiate(thingIWantToMake);
        Debug.Log(test.transform.position.x);
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal();
    }

    void moveHorizontal()
    {
        float input;

        input = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector3(input * speed, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "cannonball")
        {
            Debug.Log("oops");
            GameManager.endMiniGame(false);
        }
    }

    //Random.Range()
    //Instantiate()
}

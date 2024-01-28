using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMove : MonoBehaviour
{
    enum KeyType
    {
        Q,
        W,
        E,
        R
    }
    // Start is called before the first frame update
    [SerializeField] private float movementSpeed;
    [SerializeField] private KeyType key;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //rb.AddRelativeForce(Vector2.up * movementSpeed * Time.deltaTime);
        rb.velocity = Vector2.up * movementSpeed * Time.deltaTime;
       // playerRigidBody.velocity = new Vector2(movementSpeed * inputHorizontal, playerRigidBody.velocity.y);

        //transform.Translate(Vector2.up * movementSpeed * Time.deltaTime);
        if (transform.position.y > 4.9f)
        {
            GameManager.endMiniGame(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("keymain"))
        {
            if (key == KeyType.Q)
            {
                arrowmatchstatics.qKeyPressable = true;
                arrowmatchstatics.qkey = this.gameObject;
                Debug.Log("Q Key Pressable");
            }
            else if (key == KeyType.W)
            {
                arrowmatchstatics.wKeyPressable = true;
                arrowmatchstatics.wkey = this.gameObject;
                Debug.Log("W Key Pressable");

            }
            else if (key == KeyType.E)
            {
                arrowmatchstatics.eKeyPressable = true;
                arrowmatchstatics.ekey = this.gameObject;
                Debug.Log("E Key Pressable");

            }
            else if (key == KeyType.R)
            {
                arrowmatchstatics.rKeyPressable = true;
                arrowmatchstatics.rkey = this.gameObject;
                Debug.Log("R Key Pressable");

            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("keymain"))
        {
            if (key == KeyType.Q)
            {
                arrowmatchstatics.qKeyPressable = false;
            }
            else if (key == KeyType.W)
            {
                arrowmatchstatics.wKeyPressable = false;

            }
            else if (key == KeyType.E)
            {
                arrowmatchstatics.eKeyPressable = false;

            }
            else if (key == KeyType.R)
            {
                arrowmatchstatics.rKeyPressable = false;

            }
        }
    }
}

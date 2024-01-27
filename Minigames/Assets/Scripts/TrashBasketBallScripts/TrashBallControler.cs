using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class TrashBallControler : MonoBehaviour
{
    private Rigidbody2D trashBallRigidbody2D;
    public Vector3 aimVector;
    bool farShot;
    bool canShoot;

    // Start is called before the first frame update
    void Start()
    {
        trashBallRigidbody2D = GetComponent<Rigidbody2D>();
        aimVector = new Vector3 (0, 12, 0);
        farShot = true;
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        aimTrashBall();
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            launchTrashBall();
        }
        
    }

    private void launchTrashBall()
    {
       
        if (canShoot)
        {
            canShoot = false;
            trashBallRigidbody2D.velocity = Vector3.zero;
            trashBallRigidbody2D.velocity = aimVector;
        }
        

    }

    private void aimTrashBall()
    {

        if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            if (aimVector.x > -16)
            {
                aimVector.x -= 0.02f;
            }
            

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (aimVector.x < 16)
            {
                aimVector.x += 0.02f;
            }

        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            aimVector.y = 9;
            farShot = false;
            //Debug.Log("aim row = " + aimVector.y);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            aimVector.y = 12;
            farShot = true;
            //Debug.Log("aim row = " + aimVector.y);
        }


        if (Input.GetKeyDown(KeyCode.M))
        {

            SceneManager.LoadScene("TrashBasketBall");

        }


    }

    public Vector3 getAimIndicator()
    {

        return aimVector;

    }

    public bool getFarShot()
    {
        return farShot;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag.Equals("OB"))
        {
            resetTrashBall();
        }
        else
        {
            trashBallRigidbody2D.velocity = Vector3.zero;
            transform.position = collision.transform.position;
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.4f, transform.position.z);
            trashBallRigidbody2D.gravityScale = 0f;

            Debug.Log("Yay you did it!!!");
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!canShoot && collision.gameObject.tag.Equals("SlingshotBase"))
        {

            trashBallRigidbody2D.velocity = Vector3.zero;
            aimVector = new Vector3(0, 12, 0);
            transform.position = new Vector3(0, -3.5f, 0);
            canShoot = true;

        }
    }

    private void resetTrashBall()
    {

        trashBallRigidbody2D.velocity = Vector3.zero;
        aimVector = new Vector3(0, 12, 0);
        transform.position = new Vector3(0, -3.5f, 0);
        canShoot = true;

    }


}

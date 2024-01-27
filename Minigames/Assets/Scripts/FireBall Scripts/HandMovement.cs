using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour
{
    public float movementSpeed;
    public float leftOffset;
    public float rightOffset;
    public float startPositionX;
    private bool moveRight;
    private Rigidbody2D handRB;

    public GameObject projectile;
    public Transform muzzle;

    public float firingRate;
    private float shotCooldown;
    private bool canFire = false;


    // Start is called before the first frame update
    void Start()
    {
        handRB = GetComponent<Rigidbody2D>();
        moveRight = false;
        startPositionX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        moveHand();
        fireball();
    }

    private void moveHand()
    {
        if (moveRight)
        {
            //move the hand right
            transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
        }
        else
        {
            //move the hand left
            transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
        }


        if (transform.position.x <= startPositionX - leftOffset)
        {
            moveRight = true;
        }
        else if (transform.position.x >= startPositionX + rightOffset)
        {
            moveRight = false;
        }
    }

    private void fireball()
    {
        //If the timeBetweenShots is less than or equal to zero I can shoot my weapon
        if (shotCooldown <= 0)
        {
            //Reset timeBetweenShots to the specified firingRate
            shotCooldown = firingRate;
            //allow the player to fire their gun
            canFire = true;
        }
        else
        {
            //If the timeBetweenShots is not less than or equal to zero you cannot fire yet
            //i will deduct time from timeBetweenShots until it is 0 allowing the player
            //to shoot their weapon again.
            shotCooldown -= Time.deltaTime;
        }

        //If left mouse button is clicked
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (canFire)
            {
                //After you fire you have to wait a specified amount of time 
                //to fire again so set the boolean to false.
                canFire = false;
                shootFireball();
            }
        }
    }

    private void shootFireball()
    {
        Instantiate(projectile, muzzle.position, transform.rotation);
    }
}

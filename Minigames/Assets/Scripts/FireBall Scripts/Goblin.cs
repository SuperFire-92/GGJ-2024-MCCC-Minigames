using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    public float rotateSpeed;
    public float angle;
    private bool moveRight;




    void Update()
    {
        moveRight = false;
        moveGoblin();
    }

    private void moveGoblin()
    {
        if (moveRight)
        {

            //rotate the goblin right
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        }
        else
        {
            //rotate the goblin left
            transform.Rotate(Vector3.down * rotateSpeed * Time.deltaTime);
        }


        if (transform.rotation.x <= angle)
        {
            moveRight = true;
        }
        else if (transform.position.x >= angle)
        {
            moveRight = false;
        }
    }

    public void destroyEnemy()
    {
        Destroy(this.gameObject);
    }
}

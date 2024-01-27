using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleRacerHareMovement : MonoBehaviour
{
    private Rigidbody2D hareRigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        hareRigidbody2D = GetComponent<Rigidbody2D>();
        hareRigidbody2D.velocity = new Vector3(4f, 0, 0);
    }


}

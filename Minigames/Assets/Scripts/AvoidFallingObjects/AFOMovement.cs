using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AFOMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float movementSpeed;
    private Rigidbody2D movementRigidBody;
    private float horizontalInput;
    void Start()
    {
        movementRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        movementRigidBody.velocity = new Vector2(movementSpeed * horizontalInput, movementRigidBody.velocity.y);
    }
}

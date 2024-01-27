using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManKissing : MonoBehaviour
{
    [SerializeField] private AudioSource smooch;
    [SerializeField] private AudioSource scream;
    [SerializeField] private GameObject kissCollider;
    [SerializeField] private GameObject killCollider;

    private int xMax;
    private int yMax;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        xMax = Screen.width;
        yMax = Screen.height;
    }

    void Update()
    {
        if (kissCollider.GetComponent<ColliderWin>().hasCollided == true || killCollider.GetComponent<ColliderKill>().hasCollided == true)
        {
            followMouse();
        }
        
    }
    private void followMouse()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos.x /= xMax;
        mousePos.y /= yMax;

        mousePos = Camera.main.ViewportToWorldPoint(mousePos);
        mousePos.z = 0;

        rb.MovePosition(mousePos);
    }
}

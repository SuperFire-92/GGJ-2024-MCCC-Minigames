using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public enum Orientation
    {
        Up,
        Down,
        Left,
        Right
    }
    
    [SerializeField] private Orientation orientation;
    [SerializeField] private float speed;

    [Header("References")]
    [SerializeField] private GameObject startButton;

    private void Update()
    {
        if (startButton != null)
        {
            if (startButton.GetComponent<HoverButton>().gameStarted == true)
            {
                if (orientation == Orientation.Left)
                {
                    transform.position = transform.position + Vector3.left * speed * Time.deltaTime;
                }
                if (orientation == Orientation.Right)
                {
                    transform.position = transform.position + Vector3.right * speed * Time.deltaTime;
                }
                if (orientation == Orientation.Up)
                {
                    transform.position = transform.position + Vector3.up * speed * Time.deltaTime;
                }
                if (orientation == Orientation.Down)
                {
                    transform.position = transform.position + Vector3.down * speed * Time.deltaTime;
                }
            }
        }
        else
        {
            if (orientation == Orientation.Left)
            {
                transform.position = transform.position + Vector3.left * speed * Time.deltaTime;
            }
            if (orientation == Orientation.Right)
            {
                transform.position = transform.position + Vector3.right * speed * Time.deltaTime;
            }
            if (orientation == Orientation.Up)
            {
                transform.position = transform.position + Vector3.up * speed * Time.deltaTime;
            }
            if (orientation == Orientation.Down)
            {
                transform.position = transform.position + Vector3.down * speed * Time.deltaTime;
            }
        }
    }
}

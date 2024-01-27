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

    private void Update()
    {
        if (orientation == Orientation.Left)
        {
            transform.position = transform.position + Vector3.left * speed;
        }
    }
}

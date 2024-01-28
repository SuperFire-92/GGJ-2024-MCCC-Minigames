using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ScrollerScript : MonoBehaviour
{
    private Renderer spriteRenderer;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.material.mainTextureOffset += Vector2.right * Time.deltaTime * speed;   
    }
}

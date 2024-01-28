using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    private float input;
    public float speed;
    public float cooldown;
    private Rigidbody2D rb;
    public GameObject bean;
    public Transform Shootpoint;
    private AudioSource audios;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audios = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
       
        Move();
        Shoot();
        cooldown -= Time.deltaTime;

    }
    void Move()
    {
        input = Input.GetAxisRaw("Horizontal");
       
        rb.velocity = new Vector2(input * speed, rb.velocity.y);
       
        
    }
    void Shoot()
    {
     if(cooldown <= 0)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                audios.Play();
                Instantiate(bean, Shootpoint.transform.position, Shootpoint.transform.rotation);
                cooldown = 3;
            }
            
        }
    }
}

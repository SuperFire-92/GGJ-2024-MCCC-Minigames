using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beanguy : MonoBehaviour
{
    public float force;
    public float speed;
    private Rigidbody2D rb;
    private AudioSource audios;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        applyforce();
        audios = GetComponent<AudioSource>();
        audios.Stop();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void applyforce()
    {
        rb.AddForce(rb.velocity = new Vector2(rb.velocity.x, force * speed));
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Endpoint"))
        {
            Points.addpoint();
            audios.Play();
            Destroy(collision.gameObject);
        }
    }
}

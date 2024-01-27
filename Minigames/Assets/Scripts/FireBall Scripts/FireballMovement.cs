using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMovement : MonoBehaviour
{
    public GameObject gameManager;
    private FireballMinigameManager gm;
    public float projectileSpeed;
    public float projectileLife;

    void Start()
    {
        //call the destroyBullet function after bulletLife seconds
        gm = gameManager.GetComponent<FireballMinigameManager>();
        Invoke("destroyProjectile", projectileLife);
    }

    void Update()
    {
        //You can still use tranlate to move the bullet as long as either the bullet
        //or the enemy contains a rigidbody.
        //You cannot detect collisions unless one of the game objects has a rigidbody
        transform.Translate(Vector2.up * projectileSpeed * Time.deltaTime);
    }

    void destroyProjectile()
    {
        //Remove the projectile from the screen
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gm.subtractGoblinNum();
            Debug.Log("Subtracting goblin");
            collision.gameObject.GetComponent<Goblin>().destroyEnemy();
            destroyProjectile();
        }
    }
}

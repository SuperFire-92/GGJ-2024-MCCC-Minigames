using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindMe : MonoBehaviour
{
    float xMin = -8f;
    float xMax = 8f;
    float yMin = -4f;
    float yMax = 4f;
    private bool canClick = false;
    [SerializeField] AudioSource clickSound;

    // Spawns in FindMe at a random location
    void Start()
    {
        float x;
        float y;

        x = UnityEngine.Random.Range(xMin, xMax);
        y = UnityEngine.Random.Range(yMin, yMax);

        transform.position = new Vector2(x, y);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && canClick)
        {
            clickSound.Play();
            GameManager.endMiniGame(true);
        }
    }

    private void OnMouseOver()
    {
        canClick = true;
    }

    private void OnMouseExit()
    {
        canClick = false;
    }
}

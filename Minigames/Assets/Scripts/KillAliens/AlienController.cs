using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AlienController : MonoBehaviour
{
    private Vector3 startPos;

    public float speed; //5
    public float xScale; //1
    public float yScale; //0.5

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        moveAlien();
    }

    private void moveAlien()
    {
        transform.position = startPos + (Vector3.right * Mathf.Sin(Time.timeSinceLevelLoad / 2 * speed) * xScale - Vector3.up * Mathf.Sin(Time.timeSinceLevelLoad * speed) * yScale);
    }

    private void OnMouseOver()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            //Check if there are aliens left (== 1 and not null because this alien isn't destroyed yet). If not, win
            GameObject[] aliensInScene;
            aliensInScene = GameObject.FindGameObjectsWithTag("alien");
            if (aliensInScene.Length == 1)
            {
                Debug.Log("WIN");
                //WIN CONDITION HERE
            }
            Destroy(this.gameObject);
        }
    }
}

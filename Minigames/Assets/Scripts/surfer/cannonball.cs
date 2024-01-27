using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonball : MonoBehaviour
{
    public float speed;
    public float maxHeight;

    private bool goUp;

    // Start is called before the first frame update
    void Start()
    {
        goUp = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= maxHeight)
        {
            goUp = false;
        }

        transform.position += new Vector3(0.00f, 1.00f, 0.00f) * speed * Time.deltaTime * (goUp /* comment */ ? 1f : -1f);
    }


}

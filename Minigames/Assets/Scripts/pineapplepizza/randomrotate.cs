using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomrotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int childCount;
        //bool pineappleLoverExists;

        transform.rotation = Quaternion.Euler(0.00f, 0.00f, Random.Range(-180.00f, 180.00f));

        childCount = transform.childCount;
        //pineappleLoverExists = false;

        for (int i = 0; i < childCount; ++i)
        {

            transform.GetChild(i).rotation = Quaternion.Euler(Vector3.zero);
        }
    }
}

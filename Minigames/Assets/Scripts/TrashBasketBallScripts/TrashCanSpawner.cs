using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCanSpawner : MonoBehaviour
{

    public GameObject[] spawnLocations;
    private GameObject createdTrashCan;
    public GameObject trashCan;

    // Start is called before the first frame update
    void Start()
    {
       
       createdTrashCan = Instantiate(trashCan);
       createdTrashCan.transform.position = spawnLocations[Random.Range(0, 6)].transform.position;
    }


}

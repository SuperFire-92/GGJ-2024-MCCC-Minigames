using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCanSpawner : MonoBehaviour
{

    public GameObject[] spawnLocations;
    private GameObject createdTrashCan;
    public GameObject trashCan;
    private int currentSpawn;

    // Start is called before the first frame update
    void Start()
    {
       currentSpawn = Random.Range(0, spawnLocations.Length);
       GameObject createdTrashCan = Instantiate(trashCan);
       trashCan.transform.position = spawnLocations[currentSpawn].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.N))
        //{
        //    currentSpawn = Random.Range(0, spawnLocations.Length);
        //    Debug.Log("Range = " + currentSpawn);
        //    GameObject createdTrashCan = Instantiate(trashCan);
        //    trashCan.transform.position = spawnLocations[currentSpawn].transform.position;
        //}
    }
}

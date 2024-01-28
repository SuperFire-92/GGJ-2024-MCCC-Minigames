using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaldoScript : MonoBehaviour
{
    public GameObject waldoToSpawn;
    private GameObject waldo;
    public GameObject[] spawnLocations;

    // Start is called before the first frame update
    void Start()
    {
        spawnWaldo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawnWaldo()
    {
        //int randomIndex = Random.Range(0, spawnLocations.Length);
        //Instantiate(waldoToSpawn);
        //waldoToSpawn.transform.position = new Vector2(spawnLocations[randomIndex].transform.position.x, spawnLocations[randomIndex].transform.position.y);
        waldo = Instantiate(waldoToSpawn);
        waldo.transform.position = spawnLocations[Random.Range(0, spawnLocations.Length)].gameObject.transform.position;

    }

}

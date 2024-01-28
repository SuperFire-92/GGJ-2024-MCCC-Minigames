using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAliens : MonoBehaviour
{
    public GameObject[] aliensToSpawn;
    private GameObject alien;
    public List<GameObject> spawnLocations;
    private List<int> spawnedIndexes;
    public int numOfAliensToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        spawnedIndexes = new List<int>();

        spawnAliensLoop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawnAliensLoop()
    {
        //This is kind of all over the place but whatever, it is what it is. I tried cleaning it up and it broke
        for (int i = 0; i < numOfAliensToSpawn; i++)
        {
            int randomIndex = Random.Range(0, spawnLocations.Count);
            while(!goodIndex(randomIndex))
            {
                randomIndex = Random.Range(0, spawnLocations.Count);
            }
            spawnedIndexes.Add(randomIndex);
            int whichAlien = Random.Range(0, aliensToSpawn.Length);
            alien = Instantiate(aliensToSpawn[whichAlien]);
            //Debug.Log("Num: " +  randomIndex);
            alien.transform.position = new Vector2(spawnLocations[randomIndex].transform.position.x, spawnLocations[randomIndex].transform.position.y);
        }
    }

    private bool goodIndex(int randomIndex)
    {
        //if(spawnedIndexes.Contains(randomIndex))
        //{
        //    return false;
        //}
        //else
        //{
        //    return true;
        //}
        bool good = true;
        int count = 0;
        for (int i = 0; i < spawnedIndexes.Count; i++)
        {
            if (spawnedIndexes[i] == randomIndex)
            {
                good = false;
            }
            count = i;
        }
        return good;
    }

    public void setNumOfAliensToSpawn(int num) //For if we want to change the # of aliens
    {
        numOfAliensToSpawn = num;
    }
}
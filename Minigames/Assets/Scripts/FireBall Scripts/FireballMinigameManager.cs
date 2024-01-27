using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMinigameManager : MonoBehaviour
{
    public GameObject goblin;
    public GameObject[] spawnLocations;
    private bool gameWin = false;
    static private int goblinNum=5;

    // Start is called before the first frame update
    void Start()
    {
        spawnGoblin();
    }

    // Update is called once per frame
    void Update()
    {
        checkGameWin();
    }

    public void subtractGoblinNum()
    {
        goblinNum--;
        Debug.Log(goblinNum);
    }

    private void checkGameWin()
    {
        if(goblinNum==0)
        {
            gameWin = true;
            Debug.Log("GAME WIN");
        }
    }


    void spawnGoblin()
    {
        GameObject spawnedPrefab;

        for (int i = 0; i < spawnLocations.Length; i++)
        {
            spawnedPrefab = Instantiate(goblin.gameObject);
            spawnedPrefab.transform.position = new Vector2(spawnLocations[i].transform.position.x, spawnLocations[i].transform.position.y);
        }
    }
}

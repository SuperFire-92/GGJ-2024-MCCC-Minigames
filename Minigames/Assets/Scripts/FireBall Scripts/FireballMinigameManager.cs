using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMinigameManager : MonoBehaviour
{
    public GameObject goblin;
    public GameObject[] spawnLocations;
    static int goblinNum=5;

    // Start is called before the first frame update
    void Start()
    {
        goblinNum.Equals(spawnLocations.Length);
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
    }

    private void checkGameWin()
    {
        //Debug.Log(goblinNum);
        if(goblinNum.Equals(0))
        {
            Debug.Log("Goblin Game Win");
            goblinNum = 5;
            GameManager.endMiniGame(true);
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

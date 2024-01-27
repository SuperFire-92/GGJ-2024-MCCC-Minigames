using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ArrowMatchMain : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject QKey, WKey, EKey, RKey;
    [SerializeField] private GameObject QKeySpawner, WkeySpawner, EKeySpawner, RKeyspawner;
    [SerializeField] private GameObject QKeyP, WKeyP, EKeyP, RKeyP;
    [SerializeField] private TMP_Text score;
    private int successfulkeypresses;
   
    void Start()
    {
        StartCoroutine(keySpawns());
        successfulkeypresses = 0;
        StartCoroutine(endGame());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(keyPress(QKey)); 
            if(arrowmatchstatics.qKeyPressable)
            {
                Destroy(arrowmatchstatics.qkey.gameObject);
                successfulkeypresses++;
                score.SetText("SCORE: " + successfulkeypresses);
            }
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine(keyPress(WKey));
            if (arrowmatchstatics.wKeyPressable)
            {
                Destroy(arrowmatchstatics.wkey.gameObject);
                successfulkeypresses++;
                score.SetText("SCORE: " + successfulkeypresses);

            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(keyPress(EKey));
            if (arrowmatchstatics.eKeyPressable)
            {
                Destroy(arrowmatchstatics.ekey.gameObject);
                successfulkeypresses++;
                score.SetText("SCORE: " + successfulkeypresses);

            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(keyPress(RKey));
            if (arrowmatchstatics.rKeyPressable)
            {
                Destroy(arrowmatchstatics.rkey.gameObject);
                successfulkeypresses++;
                score.SetText("SCORE: " + successfulkeypresses);

            }
        }
    }

    IEnumerator keyPress(GameObject gameObj)
    {
        gameObj.transform.localScale = new Vector3(3.5F, 3.5F, 3.5F);
        yield return new WaitForSeconds(0.1F);
        gameObj.transform.localScale = new Vector3(3.0F, 3.0F, 3.0F);
    }

    IEnumerator keySpawns()
    {
        while(true)
        {
            yield return new WaitForSeconds(1F);
            GameObject keytoSpawn;
            int r = Random.Range(0, 4);
            if (r == 0)
            {
                keytoSpawn = Instantiate(QKeyP);
                keytoSpawn.transform.position = QKeySpawner.transform.position;
            }
            else if (r == 1)
            {
                keytoSpawn = Instantiate(WKeyP);
                keytoSpawn.transform.position = WkeySpawner.transform.position;
            }
            else if (r == 2)
            {
                keytoSpawn = Instantiate(EKeyP);
                keytoSpawn.transform.position = EKeySpawner.transform.position;
            }
            else if (r == 3)
            {
                keytoSpawn = Instantiate(RKeyP);
                keytoSpawn.transform.position = RKeyspawner.transform.position;
            }
        }
    }    

    IEnumerator endGame()
    {
        yield return new WaitForSeconds(11);
        if(successfulkeypresses >= 6)
        {
            GameManager.endMiniGame(true);
        }
        else
        {
            GameManager.endMiniGame(false);
        }
    }
}

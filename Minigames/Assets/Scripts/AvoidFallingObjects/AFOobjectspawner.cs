using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AFOobjectspawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject fallingObject;
    void Start()
    {
        StartCoroutine(spawnObjects());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnObjects()
    {
        Debug.Log("Waiting 3 Seconds");
        yield return new WaitForSeconds(1.5F);
        for(int i = 0; i < 5; i++)
        {
            float rand = Random.Range(-10, 10);
            GameObject f = Instantiate(fallingObject);
            fallingObject.transform.position = new Vector3(rand, 4.7F, 0);
        }

        yield return new WaitForSeconds(3F);
        for (int i = 0; i < 10; i++)
        {
            float rand = Random.Range(-10, 10);
            GameObject f = Instantiate(fallingObject);
            fallingObject.transform.position = new Vector3(rand, 4.7F, 0);
        }
        yield return new WaitForSeconds(3F);

        for (int i = 0; i < 15; i++)
        {
            float rand = Random.Range(-10, 10);
            GameObject f = Instantiate(fallingObject);
            fallingObject.transform.position = new Vector3(rand, 4.7F, 0);
        }
        yield return new WaitForSeconds(3F);
        Debug.Log("Player Survived Minigame Win");
    }
}

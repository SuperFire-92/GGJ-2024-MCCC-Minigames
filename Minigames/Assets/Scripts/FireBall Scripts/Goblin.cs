using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    public void destroyEnemy()
    {
        Destroy(this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemey : MonoBehaviour
{
    public GameObject enemyMain;

    void Update()
    {
        //StartCoroutine(EnemySpawn());
        GameObject enemyClone = Instantiate(enemyMain, new Vector2(0, 0), Quaternion.identity);
    }
}

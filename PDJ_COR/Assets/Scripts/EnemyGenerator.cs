using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public float timer;

    public GameObject enemy;
    public int xPos;
    public int zPos;
    public int enemyCount;
    public int enemyLimit;

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= 10){
            StartCoroutine(EnemyGenerate());
            timer = 0;
        }
    }

    IEnumerator EnemyGenerate()
    {
        enemyCount = 0;
        while (enemyCount < 2){
            xPos = Random.Range(-150, 180);
            zPos = Random.Range(-160, 140);
            Instantiate(enemy, new Vector3(xPos, 13, zPos), Quaternion.Euler(new Vector3(0, 180, 0)));
            enemyCount += 1;
            yield return new WaitForSeconds(0.1f);
        }
    }
}


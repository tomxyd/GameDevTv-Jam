using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContainer : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    private GameObject enemy;

    private void OnEnable()
    {
        PlayerCharacter.OnDeath += SpawnEnemy;
    }

    private void OnDisable()
    {
        PlayerCharacter.OnDeath -= SpawnEnemy;
    }


    private void Start()
    {
        SpawnEnemy();
    }

    void SpawnEnemy()
    {

        if (enemy == null)
        {
            enemy = Instantiate(enemyPrefab) as GameObject;
            enemy.transform.position = this.transform.position;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Player player;
    public Enemy enemyPrefab;
    public List<Enemy> enemies;

    public int enemyCount;

    public void RestartEnemyManager()
    {
        DeleteEnemies();
        GenerateEnemies();
    }

    private void GenerateEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            var enemyXPos = 0f;
            enemyXPos = UnityEngine.Random.Range(-2.5f, 2.5f);
            var newEnemy = Instantiate(enemyPrefab);
            newEnemy.transform.position = new Vector3(enemyXPos, 0, 3 + i * 1.5f);
            enemies.Add(newEnemy);
            newEnemy.StartEnemy(player);
        }        
    }

    private void DeleteEnemies()
    {

    }

    public void StopEnemies()
    {
        foreach (var e in enemies)
        {
            e.Stop();
        }
    }
}

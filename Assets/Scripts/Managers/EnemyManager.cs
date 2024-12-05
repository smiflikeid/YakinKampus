using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Player player;
    public Enemy enemyPrefab;
    public List<Enemy> enemies;

    public Vector2 enemyCount;

    public void RestartEnemyManager()
    {
        DeleteEnemies();
        GenerateEnemies();
    }

    private void GenerateEnemies()
    {
        var randomEnemyCount = UnityEngine.Random.Range(enemyCount.x, enemyCount.y);
        for (int i = 0; i < randomEnemyCount; i++)
        {
            var enemyXPos = UnityEngine.Random.Range(-2.5f, 2.5f);
            var newEnemy = Instantiate(enemyPrefab);
            newEnemy.transform.position = new Vector3(enemyXPos, 0, 3 + i * 1.5f);
            enemies.Add(newEnemy);
            newEnemy.StartEnemy(player);
        }        
    }

    private void DeleteEnemies()
    {
        foreach (var e in enemies) 
        {
            Destroy(e.gameObject);
        }
        enemies.Clear();
    }

    public void StopEnemies()
    {
        foreach (var e in enemies)
        {
            e.Stop();
        }
    }
}

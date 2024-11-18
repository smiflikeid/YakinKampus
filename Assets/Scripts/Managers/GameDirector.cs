using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public List<Enemy> enemies;
    public void LevelCompleted()
    {
        foreach (var e in enemies)
        {
            e.speed = 0;
        }
    }
}

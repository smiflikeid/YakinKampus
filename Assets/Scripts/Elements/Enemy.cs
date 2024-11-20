using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Player player;
    public float speed;

    private void Update()
    {
        if (player.isAppleCollected)
        {
            var direction = (player.transform.position - transform.position).normalized;
            transform.position += direction * Time.deltaTime * speed;
        }
    }

    public void Stop()
    {
        speed = 0;
    }
}

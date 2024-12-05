using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Player _player;
    public float speed;
    private Rigidbody _rb;
    public NavMeshAgent navMeshAgent;

    public void StartEnemy(Player player)
    {
        _player = player;
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_player.isAppleCollected)
        {
            navMeshAgent.destination = _player.transform.position;
        }
    }

    public void Stop()
    {
        navMeshAgent.speed = 0;
    }
}

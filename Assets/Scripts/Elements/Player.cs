using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameDirector gameDirector;
    public float speed = 2;

    public bool isAppleCollected;

    private Rigidbody _rb;

    public void RestartPlayer()
    {
        gameObject.SetActive(true);
        _rb = GetComponent<Rigidbody>();
        _rb.position = Vector3.zero;
        isAppleCollected = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            other.gameObject.SetActive(false);
            gameDirector.levelManager.AppleCollected();
            isAppleCollected = true;
        }
        if (other.CompareTag("Door") && isAppleCollected)
        {
            gameDirector.LevelCompleted();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        var direction = Vector3.zero;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 5;
        }
        else
        {
            speed = 2;
        }
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
        }
        _rb.velocity = direction.normalized * speed;
    }
}

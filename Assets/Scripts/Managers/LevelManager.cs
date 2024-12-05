using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject door;
    public GameObject collectablePrefab;
    public List<GameObject> collectables;

    public void RestartLevel()
    {
        DeactivateDoor();
        RandomizeDoorPosition();
        DeleteCollectables();
        GenerateCollectables();
    }

    private void DeleteCollectables()
    {
        foreach (GameObject c in collectables) 
        {
            Destroy(c);
        }
        collectables.Clear();
    }

    private void GenerateCollectables()
    {
        var newCollectable = Instantiate(collectablePrefab);
        newCollectable.transform.position = new Vector3(Random.Range(-2.5f,2.5f),0,11);
        collectables.Add(newCollectable);
    }

    private void RandomizeDoorPosition()
    {
        var pos = door.transform.position;
        pos.x = Random.Range(-2.2f, 2.2f);
        door.transform.position = pos;
    }

    private void DeactivateDoor()
    {
        door.SetActive(false);
    }

    public void AppleCollected()
    {
        door.SetActive(true);
    }
}

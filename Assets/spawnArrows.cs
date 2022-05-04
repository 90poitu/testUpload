using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnArrows : MonoBehaviour
{
    public float timeBetweenSpawn;
    public GameObject[] arrows;
    public Transform arrowContainer;
    void Update()
    {
        if (timeBetweenSpawn <= 0)
        {
            spawn();
            timeBetweenSpawn = 2;
        }
        else
        {
            timeBetweenSpawn -= Time.deltaTime;
        }
    }

    public void spawn()
    {
        GameObject spawnedArrow = Instantiate(arrows[Random.Range(0, arrows.Length)], arrowContainer.position, Quaternion.identity);
        spawnedArrow.transform.SetParent(arrowContainer);
    
    }
}

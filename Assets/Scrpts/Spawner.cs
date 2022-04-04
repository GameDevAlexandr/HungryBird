using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] insectObjects;
    [SerializeField] private float timeBetween;
    [SerializeField] private float ySpread;
    [SerializeField] private float timeSpread;
    [SerializeField] private float delay;
    private float spawnTimer;
    private float spreadTimer;
    private float delayTimer;
    void Start()
    {
        spawnTimer = Time.time;
        spreadTimer = timeBetween+ Random.Range(-timeSpread, timeSpread);
        delayTimer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - delayTimer > delay)
        {
            if (Time.time - spawnTimer >= spreadTimer)
            {
                Spawn();
            }
        }
    }
    private void Spawn()
    {
        Vector2 insectPosition = new Vector2(12, Random.Range(-ySpread,ySpread));
        Instantiate(insectObjects[Random.Range(0, insectObjects.Length)], insectPosition, Quaternion.identity);
        spawnTimer = Time.time;
        spreadTimer = timeBetween + Random.Range(-timeSpread, timeSpread);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject Enemy;
    public float TimeBTWSpawn;
    public List<GameObject> Spawner = new List<GameObject>();
    public float EnemyCount;

    void Start()
    {

    }

    void Update()
    {
        if (TimeBTWSpawn <= 0 && EnemyCount != 0)
        {
            GameObject go = Spawner[Random.Range(0, Spawner.Count)];
            Instantiate(Enemy, new Vector3(go.transform.position.x, go.transform.position.y, 0), transform.rotation);
            TimeBTWSpawn = 3;
            EnemyCount--;
        }
        else
            TimeBTWSpawn -= Time.deltaTime;
    }
}

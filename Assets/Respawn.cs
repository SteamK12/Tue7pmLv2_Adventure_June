using System.Collections;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    Vector3 spawnCenter;
    public float spawnRadius;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnCenter = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnEnemy()
    {
        RespawnManager manager = FindFirstObjectByType<RespawnManager>();
        manager.RespawnDelay(1, gameObject);
        GetComponent<Health>().ResetHP();
        transform.position = spawnCenter;
        gameObject.SetActive(false);
    }

    
}

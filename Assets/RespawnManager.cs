using System.Collections;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnDelay(float spawnDelay, GameObject enemy)
    {
        print("respawn please");
        StartCoroutine(RespawnEnemy(spawnDelay, enemy));
    }

    IEnumerator RespawnEnemy(float spawnDelay, GameObject enemy)
    {
        yield return new WaitForSeconds(spawnDelay);
        enemy.SetActive(true);
    }
}

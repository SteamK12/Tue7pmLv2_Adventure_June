using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float shootDelay;
    public GameObject enemyProjectile;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ShootPlayer());
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform);
    }

    IEnumerator ShootPlayer()
    {
        GameObject newProjectile = Instantiate(enemyProjectile);
        newProjectile.transform.position = transform.position + transform.forward;
        newProjectile.transform.rotation = transform.rotation;
        newProjectile.tag = tag;

        yield return new WaitForSeconds(shootDelay);
        while(GetComponent<EnemyMovement>().IsPlayerInRange() == false)
        {
            yield return new WaitForSeconds(0.1f);
        }
        StartCoroutine(ShootPlayer());
    }
}

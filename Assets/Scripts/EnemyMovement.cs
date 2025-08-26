using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    NavMeshAgent ai;
    GameObject player;
    public float speed = 3.5f;
    public float detectionRadius = 10;

    // Start is called once at start
    void Start()
    {
        ai = GetComponent<NavMeshAgent>();
        ai.speed = speed;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPlayerInRange())
        {
            ai.destination = player.transform.position;
        }
        else
        {
            ai.destination = transform.position;
        }
        //Add buffer
    }

    public bool IsPlayerInRange()
    {
        return Vector3.Distance(transform.position, player.transform.position) < detectionRadius;
    }
}

using UnityEngine;
using UnityEngine.AI;

public class ZombieChase : MonoBehaviour
{
    public float speed = 3f;
    public float damage = 10f;
    public float attackDistance = 2f;

    private Transform player;
    private NavMeshAgent agent;
    private PlayerHealth playerHealth;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();

        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > attackDistance)
        {
            agent.SetDestination(player.position);
        }
        else
        {
            agent.ResetPath();
            playerHealth.TakeDamage(damage * Time.deltaTime);
        }
    }
}
using UnityEngine;
using UnityEngine.AI;

public class EnemyAgent : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = player.position;
    }

    private void Update()
    {
        agent.SetDestination(player.position);
    }
}

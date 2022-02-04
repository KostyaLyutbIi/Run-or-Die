using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class EnemyPatrolling : MonoBehaviour
{
    public GameObject player;
    public List<Transform> targets;

    public float distance;
    private float _radius = 30f;

    private NavMeshAgent _agent;
    private int i;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Target()
    {
        i = Random.Range(0, targets.Count);
    }

    void Update()
    {
        if (_agent.transform.position == _agent.pathEndPosition)
        {
            Target();
            _agent.SetDestination(targets[i].position);
        }

        distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance < _radius)
        {
            _agent.SetDestination(player.transform.position);
        }
    }
}
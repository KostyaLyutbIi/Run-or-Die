using UnityEngine;
using UnityEngine.AI;

public class EnemyAgent : MonoBehaviour
{
    public GameObject player;

    public float distance;
    public float radius = 8;
    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance > radius)
            _agent.enabled = false;

        if (distance < radius)
        {
            _agent.enabled = true;
            _agent.SetDestination(player.transform.position);
        }
            
    }


    /*public Transform player;

    private NavMeshAgent _agent;
    private float _distance = 15;
    private float _radius = 10;

    void Start() 
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.destination = player.position;
    }

    private void Update()
    {
        _distance = Vector3.Distance(player.transform.position, transform.position);

        if (_distance > _radius)
            _agent.enabled = false;

        if (_distance < _radius)
        {
            _agent.enabled = true;
            _agent.SetDestination(player.transform.position);
        }
    }*/
}
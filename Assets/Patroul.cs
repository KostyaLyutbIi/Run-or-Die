using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patroul : StateMachineBehaviour
{
    float timer;

    List<Transform> target = new List<Transform>();
    NavMeshAgent _agent;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        Transform targetObject = GameObject.FindGameObjectWithTag("Target").transform;

        foreach (Transform t in targetObject)
            target.Add(t);

        _agent = animator.GetComponent<NavMeshAgent>();
        _agent.SetDestination(target[0].position);

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_agent.remainingDistance <= _agent.stoppingDistance)
            _agent.SetDestination(target[Random.Range(0, target.Count)].position);

        timer += Time.deltaTime;
        if (timer > 20)
            animator.SetBool("Walk", false);


    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent.SetDestination(_agent.transform.position);
    }
}
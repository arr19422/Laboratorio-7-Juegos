using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    public GameObject[] wayPointsArray;

    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.autoBraking = false;


    }

    // Update is called once per frame
    void Update()
    {
        if (agent && agent.remainingDistance < 0.5f)
        {
            agent.SetDestination(wayPointsArray[Random.Range(0, wayPointsArray.Length)].transform.position);
        }
    }
}

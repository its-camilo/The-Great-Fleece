using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{
    public List<Transform> wayPoints;
    public int currentTarget;
    [SerializeField]
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        //if (wayPoints.Count > 0)
        //{
        //    if (wayPoints[0]  != null)
        //    {
        //        currentTarget = wayPoints[0];
        //        agent.SetDestination(currentTarget.position);
        //    }
        //}
    }

    // Update is called once per frame
    void Update()
    {
        //if (currentTarget != null)
        //{
        //    float distance = Vector3.Distance(transform.position, currentTarget.position);

        //    if (distance < 1f)
        //    {
        //        if (wayPoints[1] != null && currentTarget != wayPoints[1])
        //        {
        //            currentTarget = wayPoints[1];
        //            agent.SetDestination(currentTarget.position);
        //        }

        //        else if (wayPoints[2] != null)
        //        {
        //            currentTarget = wayPoints[2];
        //            agent.SetDestination(currentTarget.position);
        //        }
        //    }
        //}

        if (wayPoints.Count > 0 && wayPoints[currentTarget] != null)
        {
            agent.SetDestination(wayPoints[currentTarget].position);

            float distance = Vector3.Distance(transform.position, wayPoints[currentTarget].position);

            if (distance < 1f)
            {
                currentTarget++;
            }
        }
    }
}

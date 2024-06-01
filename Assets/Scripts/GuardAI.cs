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
    private bool reverse;
    private bool targetReached;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (wayPoints.Count > 0 && wayPoints[currentTarget] != null)
        {
            agent.SetDestination(wayPoints[currentTarget].position);

            float distance = Vector3.Distance(transform.position, wayPoints[currentTarget].position);

            if (distance < 1f && targetReached is false)
            {
                if (currentTarget is 0 || currentTarget == wayPoints.Count - 1)
                {
                    targetReached = true;
                    StartCoroutine(WaitBeforemoving());
                }

                else
                {
                    if (reverse)
                    {
                        currentTarget--;

                        if (currentTarget <= 0)
                        {
                            reverse = false;
                            currentTarget = 0;
                        }
                    }

                    else
                    {
                        currentTarget++;
                    }
                }
            }
        }
    }

    IEnumerator WaitBeforemoving()
    {
        if (currentTarget is 0)
        {
            yield return new WaitForSeconds(2f);
        }

        else if (currentTarget == wayPoints.Count - 1)
        {
            yield return new WaitForSeconds(2f);
        }

        if (reverse)
        {
            currentTarget--;

            if (currentTarget is 0)
            {
                reverse = false;
                currentTarget = 0;
            }
        }

        else if (!reverse)
        {
            currentTarget++;

            if (currentTarget == wayPoints.Count)
            {
                reverse = true;
                currentTarget--;
            }
        }

        targetReached = false;
    }
}

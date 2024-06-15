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
    private Animator anim;
    public bool coinTossed;
    public Vector3 coinPos;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (wayPoints.Count > 0 && wayPoints[currentTarget] != null && !coinTossed)
        {
            agent.SetDestination(wayPoints[currentTarget].position);

            float distance = Vector3.Distance(transform.position, wayPoints[currentTarget].position);

            if (distance < 1 && (currentTarget is 0 || currentTarget == wayPoints.Count - 1))
            {
                if (anim != null)
                {
                    anim.SetBool("Walk", false);
                }
            }

            else
            {
                if (anim != null)
                {
                    anim.SetBool("Walk", true);
                }
            }

            if (distance < 1f && targetReached is false)
            {
                if (wayPoints.Count < 2)
                {
                    return;
                }

                if ((currentTarget is 0 || currentTarget == wayPoints.Count - 1) && wayPoints.Count > 1)
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

        else
        {
            float distance = Vector3.Distance(transform.position, coinPos);

            if (distance < 4f)
            {
                anim.SetBool("Walk", false);
            }
        }
    }

    IEnumerator WaitBeforemoving()
    {
        if (currentTarget is 0)
        {
            yield return new WaitForSeconds(Random.Range(2, 6));
        }

        else if (currentTarget == wayPoints.Count - 1)
        {
            yield return new WaitForSeconds(Random.Range(2, 6));
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

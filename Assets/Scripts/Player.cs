using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;
    private Vector3 target;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                //Debug.Log("Hit: " + hitInfo.point);

                agent.SetDestination(hitInfo.point);
                anim.SetBool("Walk", true);
                target = hitInfo.point;

                //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                //cube.transform.position = hitInfo.point;
            }
        }

        float distance = Vector3.Distance(transform.position, target);

        if (distance < 1f)
        {
            anim.SetBool("Walk", false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControllerNav : MonoBehaviour
{

    /// <summary>
    /// https://docs.unity3d.com/Manual/nav-AgentPatrol.html
    /// </summary>




    public Transform[] points;

    public GameObject FollowPlayerEnemy;
    Rigidbody rb;

    private int destPoint = 0;
    private NavMeshAgent agent;



    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //rb = GetComponent<Rigidbody>();
        //rb.isKinematic = true;

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;


        GotoNextPoint();
    }

    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        var distance = Vector3.Distance(gameObject.transform.position, FollowPlayerEnemy.transform.position);
        if (distance > 8f)
        {
            if (FollowPlayerEnemy != null)
            {
                GotoNextPoint();
            }
            else if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                GotoNextPoint();
            }
        }
        else
        {
            agent.destination = FollowPlayerEnemy.transform.position;
        }
    }

    public void GotoNextPoint()
    {

        // Returns if no points have been set up
        if (points.Length == 0)
        {
            return;
        }

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Player DeD");
        }
    }

}

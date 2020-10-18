using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    UnityEngine.AI.NavMeshAgent nma;
    // Animator animator;
    public GameObject[] waypoints;
    public int currWaypoint;
    public float enemySpeed = 10f;

    public enum AIState {
        Patrol,
        Chase
    }

    public AIState aiState;
    void Start()
    {
        nma = GetComponent<UnityEngine.AI.NavMeshAgent>();
        // animator = GetComponent<Animator>();
        setNextWaypoint();
        currWaypoint = -1;
    }

    // Update is called once per frame
    void Update()
    {
        // Distance between the player and the enemy
        float dist = Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, this.transform.position);

        if (dist < 30f && aiState == AIState.Patrol) {
            aiState = AIState.Chase;
            print("chase");
        } else if (dist > 40f && aiState == AIState.Chase) {
            aiState = AIState.Patrol;
            setNextWaypoint();
            print("chase no mo");
        }

        switch (aiState) {
            case AIState.Patrol:
                if (nma.remainingDistance == 0 && nma.pathPending != true) {
                    setNextWaypoint();
                }
                // animator.SetFloat("vely", nma.velocity.magnitude / nma.speed);
                break;
            case AIState.Chase:
                // Vector3 displacement = this.transform.position - GameObject.FindGameObjectWithTag("Player").transform.position;
                // gameObject.GetComponent<Rigidbody>().velocity = Vector3.Normalize(displacement) * enemySpeed;
                nma.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
                // animator.SetFloat("vely", nma.velocity.magnitude / nma.speed);
                break;
            default:
                break;
        }
    }

    private void setNextWaypoint() {
        if (waypoints.Length == 0) {
            print("waypoints is empty");
        } else {
            if (currWaypoint >= waypoints.Length - 1) {
                currWaypoint = 0;
            } else {
                currWaypoint++;
            }
            // if (currWaypoint == 5) { // If player is within certain radius
            //     float dist = Vector3.Distance(waypoints[5].transform.position, this.transform.position);
            //     float lookAheadT = dist / nma.speed - 1;
            //     Vector3 futureTarget = waypoints[5].transform.position + lookAheadT * waypoints[5].GetComponent<VelocityReporter>().velocity; // Player - Enemy -> then magnitude for scalar distance
            //     nma.SetDestination(futureTarget);
            // } else {
            nma.SetDestination(waypoints[currWaypoint].transform.position);
            // }
        }
    }
}

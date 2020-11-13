using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    UnityEngine.AI.NavMeshAgent nma;
    Animator animator;
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
        animator = GetComponent<Animator>();
        setNextWaypoint();
        currWaypoint = -1;
        animator.SetBool("Chase", false);
    }

    // Update is called once per frame
    void Update()
    {
        // Distance between the player and the enemy
        float dist = Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, this.transform.position);

        if (dist < 30f && aiState == AIState.Patrol) {
            aiState = AIState.Chase;
            animator.SetBool("Chase", true);
            nma.speed = 20.0f;
        } else if (dist > 40f && aiState == AIState.Chase) {
            aiState = AIState.Patrol;
            animator.SetBool("Chase", false);
            setNextWaypoint();
            nma.speed = 2.0f;
        }

        switch (aiState) {
            case AIState.Patrol:
                if (nma.remainingDistance == 0 && nma.pathPending != true) {
                    setNextWaypoint();
                }
                break;
            case AIState.Chase:
                nma.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
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
            nma.SetDestination(waypoints[currWaypoint].transform.position);
        }
    }
}

using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float viewDistance = 10f;
    public float viewAngle = 90f;

    private Transform player;
    private Transform currentTarget;
    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentTarget = patrolPoints[0];
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(currentTarget.position);
    }

    private void Update()
    {
        if (CanSeeTarget(player))
        {
            currentTarget = player;
            navMeshAgent.SetDestination(currentTarget.position);
        }

        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            // Si el enemigo ha alcanzado su destino actual, pasa al siguiente punto de patrulla
            NextPatrolPoint();
        }
    }

    private void NextPatrolPoint()
    {
        // Selecciona el siguiente punto de patrulla en orden
        int nextIndex = (System.Array.IndexOf(patrolPoints, currentTarget) + 1) % patrolPoints.Length;
        currentTarget = patrolPoints[nextIndex];
        navMeshAgent.SetDestination(currentTarget.position);
    }

    private bool CanSeeTarget(Transform target)
    {
        Vector3 directionToTarget = target.position - transform.position;
        float angle = Vector3.Angle(directionToTarget, transform.forward);

        if (directionToTarget.magnitude <= viewDistance && angle <= viewAngle / 2f)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, directionToTarget, out hit, viewDistance))
            {
                if (hit.transform == target)
                {
                    return true;
                }
            }
        }

        return false;
    }
}

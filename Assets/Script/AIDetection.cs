using UnityEngine;
using UnityEngine.AI;

public class AIDetection : MonoBehaviour
{
    [Header("References")]
    public NavMeshAgent agent;
    public GameObject player;
    public LayerMask Ground;
    public EnemyState state;
    [Header("Patroling")]
    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;
    [Header("Sight")]
    public float sightRange;
    public bool playerInSightRange,playerInSight;   
    public enum EnemyState
    {
        patroling,
        chasing,
        attacking
    }
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        Ground = LayerMask.GetMask("Ground");
    }

    private void Update()
    {
        switch (state)
        {
            case EnemyState.patroling:
                Patroling();
                break;
            case EnemyState.chasing:
                ChasePlayer();
                break;
        }
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, 1 << player.layer);
        if (Physics.Raycast(transform.position, (player.transform.position - transform.position).normalized, out RaycastHit hit, Vector3.Distance(transform.position, player.transform.position))) playerInSight = hit.collider.gameObject == player;
        else playerInSight = false;
        if (playerInSightRange && state == EnemyState.patroling && playerInSight)state = EnemyState.chasing;
    }
    
    void Patroling()
    {
        if (!walkPointSet)SearchWalkPoint();
        if (walkPointSet)agent.SetDestination(walkPoint);
        if (agent.remainingDistance<1f)
            walkPointSet = false;
    }
    void ChasePlayer()
    {
        if(playerInSight)agent.SetDestination(player.transform.position);
        else state = EnemyState.patroling;
    }
    void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkPoint, -transform.up, out RaycastHit hit, 2f)){
            if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground")) walkPointSet = true;
        }
           
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}

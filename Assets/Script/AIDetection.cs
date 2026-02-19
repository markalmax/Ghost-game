using UnityEngine;
using UnityEngine.AI;

public class AIDetection : MonoBehaviour
{
    [Header("References")]
    public NavMeshAgent agent;
    public GameObject player;
    public LayerMask Ground;
    public EnemyState state;
    public AudioSource ass;
    [Header("Patroling")]
    public Vector3 walkPoint;
    public GameObject point;
    public Transform[] points;
    public int pointIndex;
    public bool walkPointSet;
    public float walkPointRange;
    [Header("Sight")]
    public float sightRange;
    public bool playerInSightRange,playerInSight;   
    [Header("Audio")]
    public AudioClip wind;
    public AudioClip chase;

    public enum EnemyState
    {
        patroling,
        chasing,
        lost,
        attacking
    }
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ass = GetComponent<AudioSource>();
        player = GameObject.FindWithTag("Player");
        Ground = LayerMask.GetMask("Ground");
        point = GameObject.Find("point");
        if (points != null)
        {
        points = new Transform[point.transform.childCount];
            for (int i = 0; i < point.transform.childCount; i++)
            {
                points[i] = point.transform.GetChild(i);
            }
        }
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
            case EnemyState.lost:
                LostPlayer();
                break;
        }
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, 1 << player.layer);
        if (Physics.Raycast(transform.position, (player.transform.position - transform.position).normalized, out RaycastHit hit, Vector3.Distance(transform.position, player.transform.position))) playerInSight = hit.collider.gameObject == player;
        else playerInSight = false;
        if (playerInSightRange && state == EnemyState.patroling && playerInSight){
            state = EnemyState.chasing;
            ass.clip = chase;
            ass.Play();
        }
    }
    
    void Patroling()
    {
        if (!walkPointSet){
            if (points.Length == 0) SearchWalkPoint();
            SetWalkPoint();
        }
        if (walkPointSet)agent.SetDestination(walkPoint);
        if (agent.remainingDistance<1f){
            walkPointSet = false;
            if (points.Length > 0) pointIndex++;
        }    
    }
    void ChasePlayer()
    {
        if(playerInSight)agent.SetDestination(player.transform.position);
        else state = EnemyState.lost;
    }
    void LostPlayer()
    {
        walkPoint = player.transform.position;walkPointSet = true;
        if (agent.remainingDistance<1f&&!playerInSight){
        walkPointSet = false;
        ass.clip = wind;
        ass.Play();
        state = EnemyState.patroling;
        }
        else if(playerInSight)state = EnemyState.chasing;    
    }
    void SetWalkPoint()
    {
        if (pointIndex >= points.Length)
        {
            pointIndex = 0;
            walkPoint = points[0].position;
        } 
        else walkPoint = points[pointIndex].position;
        walkPointSet = true;
    }
    void SearchWalkPoint()
    {
        walkPoint = new Vector3(transform.position.x + Random.Range(-walkPointRange, walkPointRange), transform.position.y, transform.position.z + Random.Range(-walkPointRange, walkPointRange));
        if (Physics.Raycast(walkPoint, -transform.up, out RaycastHit hit, 2f)){
            if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground")) walkPointSet = true;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        if(playerInSight)Gizmos.color = Color.red;
        else Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, player.transform.position);
    }
}

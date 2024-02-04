using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private Rigidbody rb;
    private Animator anim;
    [SerializeField] private Transform garden;
    [SerializeField] private Transform hiterPart;
    public LayerMask whatIsGround, whatIsGarden;
    
    //Patrolling
    private Vector3 walkPoint;
    private bool walkPointSet = false;
    [SerializeField] private float walkPointRange;

    //States
    private bool gardenInSightAttack;
    private bool gardenInAttackRange;
    [SerializeField] private float sightRangeRadius;
    [SerializeField] private float attackRangeRadius;

    //Attack
    [SerializeField] private float idleTime;
    [SerializeField] private float attackTime;
    [SerializeField] private int attackValue;
    [SerializeField] private Garden gardenChamp;
    private float attackCounterTime;
    private bool isAttacking;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        attackCounterTime -= Time.deltaTime;
        AnimationController();

        CollisionCheck();
   
        if(!gardenInSightAttack && !gardenInAttackRange) Patroling();

        if(gardenInSightAttack && !gardenInAttackRange) WalkToGarden();

        if (gardenInSightAttack && gardenInAttackRange) AttackGarden();
    }

    private void Patroling()
    {
        Debug.Log(agent.velocity.magnitude);
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }
        else
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if(distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }
        
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange,walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if(Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    private void WalkToGarden()
    {
        isAttacking = false;
        agent.speed = 6f;
        agent.SetDestination(garden.position);
        transform.LookAt(garden.position);
    }

    private void AttackGarden()
    {
        if( attackCounterTime < 0 )
        {
            isAttacking = true;
            attackCounterTime = attackTime;
            gardenChamp.GetHit(attackValue);
        }
        else
        {
       
            isAttacking = false;
        }
        agent.SetDestination(transform.position);
        transform.LookAt(garden.position);
    }

    private void CollisionCheck()
    {
        gardenInSightAttack = Physics.CheckSphere(transform.position, sightRangeRadius, whatIsGarden);
        gardenInAttackRange = Physics.CheckSphere(transform.position, attackRangeRadius, whatIsGarden);
    }

    private void AnimationController()
    {
        anim.SetFloat("velocity", agent.velocity.magnitude);
        anim.SetBool("isMoving", agent.velocity.magnitude > 0);
        anim.SetBool("isAttacking", isAttacking);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRangeRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRangeRadius);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{

    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, WhatIsPlayer;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    public float patrolSpeed = 3f;

    //attacking
    public float timeBetweenAttacks;
    public float chaseSpeed = 5f;
    bool alreadyAttacked;

    //states
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    public Animator animator;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        animator = GetComponentInChildren<Animator>(); 
    }


    private void Update()
    {

        if(Mathf.Abs(agent.velocity.x + agent.velocity.z) > 0) 
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }



        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, WhatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Invoke("Patroling", 6f);
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        //if (playerInAttackRange && playerInSightRange) AttackPlayer();

      
    }

    private void Patroling()
    {
        GetComponent<NavMeshAgent>().speed = patrolSpeed;
        if (!walkPointSet) SearchWalkPoint();
        if (walkPointSet)
        {
            agent.SetDestination(walkPoint); 

            Vector3 distanceToWalkPoint = transform.position - walkPoint;

            //walkpoint reached
            if (distanceToWalkPoint.magnitude < 1f)
            {
                walkPointSet = false;
            }
        }
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
        
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        GetComponent<NavMeshAgent>().speed = chaseSpeed;
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player);
    }

}

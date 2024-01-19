using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class EnemyStanding : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public Vector3 walkPoint;
    public bool walkPointSet, alreadyAttacked, playerInSightRange, playerInAttackRange;
    public float walkPointRange, timeBetweenAttacks, sightRange, attackRange;
    [Inject] private PlayerAction _playerAction;
    private Weapon _weapon;
    private float _reloadCompletionTime = 1f;

    private void Chasing()
    {
        agent.SetDestination(player.position);
    }

    private void Attacking()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(new Vector3(player.position.x, player.position.y - 0.3f, player.position.z));

        if (!alreadyAttacked && _weapon.ammoInMagazine > 0)
        {
            _weapon.Shoot();
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void StartReload()
    {
        Invoke("CompleteReload", _reloadCompletionTime);
    }

    private void CompleteReload()
    {
        _weapon.Reload();
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }



    private void Awake()
    {
        player = _playerAction.gameObject.transform;
        agent = GetComponent<NavMeshAgent>();
        _weapon = GetComponentInChildren<Weapon>();
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (playerInSightRange && !playerInAttackRange)
            Chasing();
        if (playerInSightRange && playerInAttackRange)
            Attacking();

        if (_weapon.ammoInMagazine == 0)
        {
            StartReload();
        }

    }
}

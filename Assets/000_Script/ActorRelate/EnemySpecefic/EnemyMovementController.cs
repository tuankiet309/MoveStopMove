using UnityEngine.AI;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    //Cac component can thiet de giao tiep va theo doi
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform pointHolder;  
    [SerializeField] private ActorAttacker attacker;

    //Gia tri ban dau
    private float rotationSpeed;

    //Gan trong runtime
    private Vector3 rotatedDir;
    private bool isAttacking;
    private Transform targetDes = null;


    //Su kien ke dich di chuyen de truyen vao animation controller;
    public delegate void OnEnemyMoving(Vector3 moveSpeed);
    public event OnEnemyMoving onEnemyMoving;

    private void Awake()
    {
        rotationSpeed = CONSTANT_VALUE.FIRST_ROTATIONSPEED;
        agent.speed = CONSTANT_VALUE.FIRST_MOVESPEED_ENEMY;
    }
    private void Start()
    {
        SetNewDestination();
        attacker.onHaveTarget += IsTargetInRange;
        attacker.onActorAttack += IsAttackingRightNow;
    }

    private void Update()
    {
        if (isAttacking && targetDes != null)
        {
            RotateTowardsTarget(); 
        }
        else
        {
            RotateTowardsMovementDirection(); 
        }

        if (agent.isStopped)
        {
            onEnemyMoving?.Invoke(Vector3.zero);
        }
        else
        {
            onEnemyMoving?.Invoke(agent.velocity);
        }

        if (!isAttacking && !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            SetNewDestination();
        }
    }

    private void RotateTowardsMovementDirection()
    {
        if (agent.velocity.sqrMagnitude > 0.1f)
        {
            Vector3 direction = agent.velocity.normalized;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }

    private void RotateTowardsTarget()
    {
        if (targetDes != null)
        {
            Vector3 direction = (targetDes.position - transform.position).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }

    private void SetNewDestination()
    {
        int random = Random.Range(0, pointHolder.childCount);
        Vector3 destination = pointHolder.GetChild(random).position;
        agent.SetDestination(destination);
    }



    private void IsTargetInRange(GameObject target)
    {
        if (target != null)
        {
            targetDes = target.transform;
            isAttacking = true;
            agent.isStopped = true;
        }
        else
        {
            targetDes = null;
            isAttacking = false;
            agent.isStopped = false;
        }
    }

    private void IsAttackingRightNow(Vector2 pos)
    {
        rotatedDir = pos;
    }

    public void SetUpPointHolder(Transform pointHolder)
    {
        this.pointHolder = pointHolder;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform targetTransform;
    [SerializeField] Animator animator;
    

    private void SetDestination(GameObject target)
    {
        targetTransform = target.transform;
    }
}

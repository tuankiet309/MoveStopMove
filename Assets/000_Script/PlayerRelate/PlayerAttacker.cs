using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacker : MonoBehaviour, IAttacker
{
    [SerializeField] private AttackCirle attackCirle;
    [SerializeField] private Projectile projectile;
    [SerializeField] private float delayTimeToAttack;
    [SerializeField] private Transform throwLocation;
    [SerializeField] private LayerMask possibleDecorationBlock;
    private LinkedList<GameObject> enemyAttacker = new LinkedList<GameObject>();
    private GameObject targetToAttack = null;

    public delegate void OnPlayerAttack(Vector2 pos,bool temp);
    public event OnPlayerAttack onPlayerAttack;
    void Start()
    {
        if (attackCirle == null)
            return;
        attackCirle.onTriggerContact += UpdateEnemyList;
    }
    public void PrepareToAttack()
    {
        targetToAttack = GetTargetToAttack();
        if (targetToAttack == null)
            return;
        Vector3 attackDir = targetToAttack.transform.position - transform.position;

        onPlayerAttack?.Invoke( new Vector2(attackDir.x, attackDir.z),true);

        StartCoroutine(Attack(targetToAttack.transform.position));
    }
    IEnumerator Attack(Vector3 enemyLoc)
    {
        IProjectile newProjectile = Instantiate(projectile, throwLocation.position, Quaternion.identity, null);
        newProjectile.Init(this);
        newProjectile.FlyToPos(enemyLoc);
        yield return null;
    }
    public void DoSomethingToo()
    {
        throw new System.NotImplementedException();
    }
  
    void UpdateEnemyList(GameObject target,bool isInCircle)
    {
        if(isInCircle && !enemyAttacker.Contains(target)) 
            enemyAttacker.AddLast(target);
        else if(enemyAttacker.Contains(target))
            enemyAttacker.Remove(target);
    }


    private GameObject GetTargetToAttack()
    {
        if(enemyAttacker.Count!=0)
            return enemyAttacker.First.Value;
        else return null;
    }
}

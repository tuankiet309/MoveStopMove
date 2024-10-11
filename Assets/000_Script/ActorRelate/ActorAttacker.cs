using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActorAttacker : MonoBehaviour, IAttacker
{
    [SerializeField] private DetectionCircle attackCircle;
    [SerializeField] private Transform throwLocation;
    [SerializeField] private GameObject targetCircleInstance;

    private HashSet<GameObject> enemyAttackers = new HashSet<GameObject>();
    private GameObject targetToAttack = null;
    private Vector3 targetToAttackPos = Vector3.zero;
    private Weapon weapon1;

    public delegate void OnActorAttack(Vector2 pos);
    public event OnActorAttack onActorAttack;

    public delegate void OnHaveTarget(GameObject target);
    public event OnHaveTarget onHaveTarget;

    public UnityEvent onKillSomeone;

    private void OnEnable()
    {
        if (attackCircle != null)
        {
            attackCircle.onTriggerContact += UpdateEnemyList;
        }
    }
    private void OnDisable()
    {
        if (attackCircle != null) 
        {
            attackCircle.onTriggerContact -= UpdateEnemyList;
        }
    }

    private void Update()
    {
        CheckAndUpdateTargetCircle();
    }

    public void PrepareToAttack()
    {
        if (targetToAttack == null) return; 
        Vector3 attackDir = targetToAttackPos - transform.position;
        onActorAttack?.Invoke(new Vector2(attackDir.x, attackDir.z));
        StartCoroutine(Attack(targetToAttackPos));
    }

    private IEnumerator Attack(Vector3 enemyLoc)
    {
        Projectile newProjectile = Instantiate(weapon1.WeaponThrowAway, throwLocation.position, Quaternion.identity);
        newProjectile.Init(this, attackCircle.CircleRadius, CONSTANT_VALUE.PROJECTILE_FLY_SPEED, weapon1.WeaponType);
        newProjectile.FlyToPos(enemyLoc);
        yield return null;
    }

    public void EventIfKillSomeone()
    {
        onKillSomeone?.Invoke();
    }

    private void UpdateEnemyList(GameObject target, bool isInCircle)
    {
        if (isInCircle && IsTargetAlive(target))
        {
            if (!enemyAttackers.Contains(target))
            {
                enemyAttackers.Add(target);  
            }
            onHaveTarget?.Invoke(target);  
        }
        else
        {
            enemyAttackers.Remove(target);   
            if (enemyAttackers.Count == 0)
                onHaveTarget?.Invoke(null);  
        }
    }

    private void CleanUpDestroyedObjects()
    {
        enemyAttackers.RemoveWhere(item => item == null || !item.activeInHierarchy || !IsTargetAlive(item));
    }

    private GameObject GetFirstValidTarget()
    {
        foreach (var target in enemyAttackers)
        {
            if (IsTargetAlive(target))
            {
                return target;
            }
        }
        return null;
    }

    private void CheckAndUpdateTargetCircle()
    {
        CleanUpDestroyedObjects();  

        targetToAttack = GetFirstValidTarget();  
        if (targetToAttack != null)
        {
            onHaveTarget?.Invoke(targetToAttack);  
            targetToAttackPos = targetToAttack.transform.position;  

            if (targetCircleInstance != null)
            {
                targetCircleInstance.SetActive(true);
                targetCircleInstance.transform.position = new Vector3(targetToAttackPos.x, targetCircleInstance.transform.position.y, targetToAttackPos.z);
            }
        }
        else
        {
            onHaveTarget?.Invoke(null); 
            if (targetCircleInstance != null)
            {
                targetCircleInstance.SetActive(false);
            }
        }
    }

    private bool IsTargetAlive(GameObject target)
    {
        LifeComponent lifeComponent = target.GetComponent<LifeComponent>();
        return lifeComponent != null && !lifeComponent.IsDying; 
    }

    public void InitWeapon(Weapon weapon)
    {
        this.weapon1 = weapon;
    }

}
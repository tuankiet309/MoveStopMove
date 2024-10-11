using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorAnimationController : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private ActorMovementController actorMovementController;
    [SerializeField] private EnemyMovementController enemyMovementController;
    [SerializeField] private ActorAttacker attacker;
    [SerializeField] private LifeComponent lifeComponent;
    [SerializeField] private WeaponComponent weaponComponent;

    private void OnEnable()
    {
        EnableEventListeners();
    }
    private void OnDisable()
    {
        DisableEventListeners();
    }
    public void EnableEventListeners()
    {
        if (weaponComponent != null)
            weaponComponent.onHavingWeapon += UpdateHavingWeapon;

        if (actorMovementController != null)
            actorMovementController.onActorMoving += UpdateMoveAnimation;

        if (lifeComponent != null)
            lifeComponent.onLifeEnds.AddListener(UpdatePlayerDead);

        if (attacker != null)
            attacker.onHaveTarget += UpdateHaveTarget;

        if (enemyMovementController != null)
            enemyMovementController.onEnemyMoving += UpdateMoveAnimation;
    }

    public void DisableEventListeners()
    {
        if (weaponComponent != null)
            weaponComponent.onHavingWeapon -= UpdateHavingWeapon;

        if (actorMovementController != null)
            actorMovementController.onActorMoving -= UpdateMoveAnimation;

        if (lifeComponent != null)
            lifeComponent.onLifeEnds.RemoveListener(UpdatePlayerDead);

        if (attacker != null)
            attacker.onHaveTarget -= UpdateHaveTarget;

        if (enemyMovementController != null)
            enemyMovementController.onEnemyMoving -= UpdateMoveAnimation;
    }

    private void UpdateMoveAnimation(Vector3 moveVec)
    {
        anim.SetBool("isMoving", moveVec != Vector3.zero);
    }

    private void UpdatePlayerDead(string temp)
    {
        anim.SetTrigger("isDead");
        lifeComponent.onLifeEnds.RemoveListener(UpdatePlayerDead);
    }

    private void UpdateHaveTarget(GameObject target)
    {
        if (target != null && !IsTargetDying(target))
        {
            anim.SetBool("haveEnemy", true);
        }
        else
        {
            anim.SetBool("haveEnemy", false);
        }
    }

    private bool IsTargetDying(GameObject target)
    {
        LifeComponent lifeComponent = target.GetComponent<LifeComponent>();
        return lifeComponent != null && lifeComponent.IsDying;
    }

    private void UpdateHavingWeapon(bool haveWeapon)
    {
        anim.SetBool("haveWeapon", haveWeapon);
    }
}
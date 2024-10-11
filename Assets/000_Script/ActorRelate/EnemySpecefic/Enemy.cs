using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static int numberOfEnemyRightnow = 0;
    public static int numberOfEnemyHasDie =0;
    private void OnEnable()
    {
        numberOfEnemyRightnow ++;

    }
    private void OnDisable()
    {
        numberOfEnemyRightnow --;
        numberOfEnemyHasDie++;
    }
    public void PrepareForDestroy()
    {
        GetComponent<Collider>().enabled = false;
        StartCoroutine(Die());
    }
    IEnumerator Die()
    {
        yield return new WaitForEndOfFrame();
        Destroy(gameObject);
    }

    public void Initialize(Material skinColor, Material pantColor, Weapon weapon, Transform pointHolder, string name)
    {
        EnemySkinController skinController = GetComponent<EnemySkinController>();
        WeaponComponent weaponComponent = GetComponent<WeaponComponent>();
        EnemyMovementController movementController = GetComponent<EnemyMovementController>();
        ActorInfomationController actorInfomationController = GetComponent<ActorInfomationController>();

        if (skinController != null)
        {
            skinController.ChangeSkin(skinColor, pantColor);
        }
        if (weaponComponent != null)
        {
            weaponComponent.AssignWeapon(weapon);
        }
        if (movementController != null)
        {
            movementController.SetUpPointHolder(pointHolder);
        }
        if(actorInfomationController != null)
        {
            actorInfomationController.UpdateName(name);
        }
    }

}

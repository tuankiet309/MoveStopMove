using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enum;

public class Projectile : MonoBehaviour, IProjectile
{
    float distanceTilDie = 2f;
    float flyVelocity = 2f;
    Enum.WeaponType weaponType;
    private Vector3 flyDirection;

    [SerializeField] DamageComponent damageComponent;
    [SerializeField] Rigidbody rb;

    private void Start()
    {
    }
    public virtual void Init(ActorAttacker Initiator, float circleRadius, float speed, Enum.WeaponType weaponType)
    { 
        damageComponent.InitIAttacker(Initiator);
        distanceTilDie = circleRadius;
        flyVelocity = speed;
        this.weaponType = weaponType;
    }
    public virtual void FlyToPos(Vector3 Enemy)
    {
        Vector3 flyDirection = Enemy - transform.position;
        flyDirection = new Vector3(flyDirection.x,transform.position.y,flyDirection.z).normalized;
        StartCoroutine(Fly(transform.position,flyDirection.normalized));

    }
    IEnumerator Fly(Vector3 initDistance,Vector3 flyDir)
    {
        while(distanceTilDie > Vector3.Distance(transform.position, initDistance))
        {
            rb.velocity = flyDir.normalized * flyVelocity;
            if (weaponType == WeaponType.Rotate)
            { 
                float rotationSpeed = CONSTANT_VALUE.PROJECTILE_ROTATE_SPEED;
                Quaternion rotation = Quaternion.Euler(0f, rotationSpeed, 0f); 
                rb.MoveRotation(rb.rotation * rotation); 
            }
            yield return null;
        }
        SelfDestroy();
    }
    private void SelfDestroy()
    {
        Destroy(gameObject);
    }
    
    

}

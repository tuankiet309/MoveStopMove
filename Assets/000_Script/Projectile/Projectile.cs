using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour, IProjectile
{
    [SerializeField] float distanceTilDie = 2f;
    [SerializeField] float flyVelocity = 2f;
    [SerializeField] Rigidbody rb;
    IAttacker Initiator;
    private Vector3 flyDirection;
    public virtual void FlyToPos(Vector3 Enemy)
    {
        Vector3 flyDirection = Enemy - transform.position;
        StartCoroutine(Fly(transform.position,flyDirection));

    }
    IEnumerator  Fly(Vector3 initDistance,Vector3 flyDir)
    {
        while(distanceTilDie > Vector3.Distance(transform.position, initDistance))
        {
            rb.velocity = flyDir * flyVelocity * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        SelfDestroy();
    }
    public virtual void Init(IAttacker Initiator)
    {
        this.Initiator = Initiator;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<IAttacker>() != null) 
        {
            SelfDestroy();
        }
    }
    private void SelfDestroy()
    {
        Destroy(gameObject);
    }
}

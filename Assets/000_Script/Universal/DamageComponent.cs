using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageComponent : MonoBehaviour
{
    private ActorAttacker Initianor;
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.GetComponent<IAttacker>() == Initianor)
            return;
        if (other.CompareTag("AttackCircle") || other.CompareTag("Projectile"))
            return;
        LifeComponent lifeComponent = other.GetComponent<LifeComponent>();
        if(lifeComponent != null )
        {
            lifeComponent.onLifeEnds?.Invoke(Initianor.GetComponent<ActorInfomationController>().GetName());
            Initianor.EventIfKillSomeone();
            SelfDestroy();
        }
    }
    public void InitIAttacker(ActorAttacker master)
    {
        Initianor = master;
    }
    private void SelfDestroy()
    {
        Destroy(gameObject);
    }

}

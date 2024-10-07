using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageComponent : MonoBehaviour
{
    private IAttacker Initianor;

    private void OnTriggerEnter(Collider other)
    {
        LifeComponent lifeComponent = other.GetComponent<LifeComponent>();
        if(lifeComponent != null )
        {
            
        }
    }
}

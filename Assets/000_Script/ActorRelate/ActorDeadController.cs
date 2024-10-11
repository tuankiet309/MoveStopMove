using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;
using UnityEngine.AI;

public class ActorDeadController : MonoBehaviour
{
    Component[] components;
    private void Start()
    {
        components = GetComponents<Component>();
    }
    public void OnDead()
    {
        for (int i = 0; i < components.Length; i++)
        {
            Behaviour behaviour = components[i] as Behaviour;

            if (behaviour != null && behaviour is not Animator && behaviour is not NavMeshAgent)
            {
                behaviour.enabled = false;
                continue;
            }
            else if(behaviour is NavMeshAgent)
            {
                (behaviour as NavMeshAgent).speed = 0;
            }
            Collider collider = components[i] as Collider;
            if (collider != null)
            {
                collider.enabled = false;
                continue;
            }

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class AttackCirle : MonoBehaviour
{
    [SerializeField] float circleRaidus = 10f;
    [SerializeField] Transform centerOfCircle;
    [SerializeField] SphereCollider colliderToChanged;

    public delegate void OnTriggerContact(GameObject attacker, bool isIn);
    public event OnTriggerContact onTriggerContact;

    private void Start()
    {
        colliderToChanged.radius = circleRaidus;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(transform.tag))
            return;
        DecorationObject decorationObject = other.GetComponent<DecorationObject>();
        IAttacker attacker = other.GetComponent<IAttacker>();
        if (decorationObject!=null && transform.CompareTag("Player"))
        {
            decorationObject.ChangeTransparentValue(true);
        }
        else if (attacker!=null)
        {
            onTriggerContact?.Invoke(other.gameObject,true);
            Debug.Log("Detected Enemy !!!");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        DecorationObject decorationObject = other.GetComponent<DecorationObject>();
        IAttacker attacker = other.GetComponent<IAttacker>();
        if (decorationObject != null)
        {
            decorationObject.ChangeTransparentValue(false);
        }
        else if (attacker != null)
        {
            onTriggerContact?.Invoke(other.gameObject, false);
            Debug.Log("No Longer Detect Enemy");
        }
    }
}

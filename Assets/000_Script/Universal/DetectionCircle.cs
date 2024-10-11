using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionCircle : MonoBehaviour
{
    private float circleRadius;
    private float circleRadiusIncreaser;

    [SerializeField] private Transform centerOfCircle;
    [SerializeField] private SphereCollider colliderToChanged;

    public float CircleRadius { get => circleRadius; }

    public delegate void OnTriggerContact(GameObject attacker, bool isIn);
    public event OnTriggerContact onTriggerContact;

    private HashSet<GameObject> trackedObjects = new HashSet<GameObject>();

    private void Awake()
    {
        circleRadius = CONSTANT_VALUE.FIRST_CIRCLE_RADIUS;
        circleRadiusIncreaser = CONSTANT_VALUE.CIRCLE_RADIUS_INCREASER;
        colliderToChanged.radius = circleRadius;
    }

    private void Start() { }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(transform.tag)) return;

        DecorationObject decorationObject = other.GetComponent<DecorationObject>();
        IAttacker attacker = other.GetComponent<IAttacker>();

        if (decorationObject != null && transform.parent.CompareTag("Player"))
        {
            decorationObject.ChangeTransparentValue(true);
        }
        else if (attacker != null)
        {
            trackedObjects.Add(other.gameObject);
            onTriggerContact?.Invoke(other.gameObject, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(transform.tag)) return;

        DecorationObject decorationObject = other.GetComponent<DecorationObject>();
        IAttacker attacker = other.GetComponent<IAttacker>();

        if (decorationObject != null && transform.parent.CompareTag("Player"))
        {
            decorationObject.ChangeTransparentValue(false);
        }
        else if (attacker != null)
        {
            trackedObjects.Remove(other.gameObject);
            onTriggerContact?.Invoke(other.gameObject, false);
        }
    }

    public void UpdateCircleRadius()
    {
        circleRadius += circleRadiusIncreaser;
        colliderToChanged.radius = circleRadius;
    }

    public void CleanUpDestroyedOrPooledObjects()
    {
        trackedObjects.RemoveWhere(item => !item.activeInHierarchy); 
    }

    public void OnObjectReturnedToPool(GameObject obj)
    {
        if (trackedObjects.Contains(obj))
        {
            trackedObjects.Remove(obj);
            onTriggerContact?.Invoke(obj, false); 
        }
    }

    public bool IsTargetInCircle(GameObject target)
    {
        return trackedObjects.Contains(target);
    }
}
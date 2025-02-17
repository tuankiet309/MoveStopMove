﻿using UnityEngine;


[DefaultExecutionOrder(0)]
public class Target : MonoBehaviour
{
    [Tooltip("Change this color to change the indicators color for this target")]
    [SerializeField] private Color targetColor = Color.red;

    [Tooltip("Select if box indicator is required for this target")]
    [SerializeField] private bool needBoxIndicator = true;

    [Tooltip("Select if arrow indicator is required for this target")]
    [SerializeField] private bool needArrowIndicator = true;

    [Tooltip("Select if distance text is required for this target")]
    [SerializeField] private bool needDistanceText = true;


    [HideInInspector] public Indicator indicator;


    public Color TargetColor
    {
        get
        {
            return targetColor;
        }
    }


    public bool NeedBoxIndicator
    {
        get
        {
            return needBoxIndicator;
        }
    }


    public bool NeedArrowIndicator
    {
        get
        {
            return needArrowIndicator;
        }
    }

    public bool NeedDistanceText
    {
        get
        {
            return needDistanceText;
        }
    }


    private void OnEnable()
    {
        if(OffScreenIndicator.TargetStateChanged != null)
        {
            OffScreenIndicator.TargetStateChanged.Invoke(this, true);
        }
    }


    private void OnDisable()
    {
        if(OffScreenIndicator.TargetStateChanged != null)
        {
            OffScreenIndicator.TargetStateChanged.Invoke(this, false);
        }
    }


    public float GetDistanceFromCamera(Vector3 cameraPosition)
    {
        float distanceFromCamera = Vector3.Distance(cameraPosition, transform.position);
        return distanceFromCamera;
    }
}

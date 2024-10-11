using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIWorldSpace : MonoBehaviour
{

    private void Start()
    {
    }
    private void LateUpdate()
    {
        Vector3 lookAtPosition = Camera.main.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(-lookAtPosition);
    }

}

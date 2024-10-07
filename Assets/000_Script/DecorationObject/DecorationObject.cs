using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorationObject : MonoBehaviour
{
    [SerializeField] Renderer _renderer;
    [SerializeField] float transparentValue;

    public void ChangeTransparentValue(bool Check)
    {      
        Color color = _renderer.material.color;
        if (Check)
            color.a = transparentValue;
        else
            color.a = 1.0f;
        _renderer.material.color = color;
    }
}

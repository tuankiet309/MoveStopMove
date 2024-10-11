using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkinController : MonoBehaviour
{
    [SerializeField] SkinnedMeshRenderer skinToChanged;
    [SerializeField] SkinnedMeshRenderer pantToChanged;
    
    public void ChangeSkin(Material skinMat, Material pantMat)
    {
        skinToChanged.material = skinMat;
        pantToChanged.material = pantMat;
    }
}

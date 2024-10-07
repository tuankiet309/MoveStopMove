using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeComponent : MonoBehaviour
{
    private int life = 1; //IDK what is this using for bruh
    public delegate void OnLifeEnds();
    public event OnLifeEnds onLifeEnds;    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enum : MonoBehaviour
{
    public enum WeaponType
    {
        Straight,  // Ball
        Rotate,    // Axe
        Comeback   // boomerang
    }
    public enum GameState
    {
        NormalPVP,
        Hall,
        ZombiCity,
        Dead,
        Ads
    }
}

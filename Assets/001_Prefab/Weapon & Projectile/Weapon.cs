using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon", order = 1)]
public class Weapon : ScriptableObject
{
    float delayTimeBetweenWeapon = 1f;

    //Cac thong so can chinh sua trong editor
    [SerializeField] GameObject weaponOnHand;
    [SerializeField] Projectile weaponThrowAway;
    [SerializeField] Vector3 weaponOffsetPos;
    [SerializeField] Quaternion weaponOffsetRot;
    [SerializeField] Enum.WeaponType weaponType;

    public GameObject WeaponOnHand { get => weaponOnHand; private set { } }
    public Projectile WeaponThrowAway { get => weaponThrowAway; private set { } }
    public float DelayTimeBetweenWeapon { get => delayTimeBetweenWeapon; private set { } }
    public Vector3 WeaponOffsetPos { get => weaponOffsetPos; private set { } }
    public Quaternion WeaponOffsetRot { get => weaponOffsetRot; private set { } }

    public Enum.WeaponType WeaponType { get => weaponType; private set { } }
}

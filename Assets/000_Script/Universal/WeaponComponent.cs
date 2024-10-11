using System.Collections;
using UnityEngine;

public class WeaponComponent : MonoBehaviour
{
    //Cac comp can thiet de giao tiep
    [SerializeField] Transform attachedLocation;
    [SerializeField] Weapon weapon;
    [SerializeField] ActorAttacker attacker;

    //Properties duoc thay doi trong runtime
    GameObject weaponOnHand;

    //Su kien co weapon
    public delegate void OnHavingWeapon(bool isHavingWeapon);
    public event OnHavingWeapon onHavingWeapon;
    private void Start()
    {
        InitWeapon();
    }
    public void AssignWeapon(Weapon weapon)
    {
        this.weapon = weapon;
        InitWeapon();
    }
    private void InitWeapon()
    {
        weaponOnHand = Instantiate(weapon.WeaponOnHand, attachedLocation.position, Quaternion.identity, attachedLocation);
        weaponOnHand.transform.localPosition = weapon.WeaponOffsetPos;
        weaponOnHand.transform.localRotation = weapon.WeaponOffsetRot;
        attacker.InitWeapon(weapon);
        attacker.onActorAttack += OnThrowAwayWeapon;
        onHavingWeapon?.Invoke(true);
    }

    private void OnThrowAwayWeapon(Vector2 hold)
    { 
        weaponOnHand.SetActive(false);
        onHavingWeapon?.Invoke(false);
        StartCoroutine(GetWeaponBack());
    }
    IEnumerator GetWeaponBack()
    {
        yield return new WaitForSeconds(weapon.DelayTimeBetweenWeapon);
        weaponOnHand.SetActive(true);
        onHavingWeapon?.Invoke(true);
    }   
}

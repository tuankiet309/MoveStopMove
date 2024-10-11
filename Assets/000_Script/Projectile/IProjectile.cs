using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProjectile
{
    void Init(ActorAttacker Initiator,float howFar, float speed, Enum.WeaponType weaponType);
    void FlyToPos(Vector3 Enemy);

}

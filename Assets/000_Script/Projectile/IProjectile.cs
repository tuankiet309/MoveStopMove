using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProjectile
{
    void Init(IAttacker Initiator);
    void FlyToPos(Vector3 Enemy);

}

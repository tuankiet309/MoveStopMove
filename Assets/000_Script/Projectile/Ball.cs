using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : Projectile
{
    public override void Init(IAttacker Initiator)
    {
        base.Init(Initiator);
    }
    public override void FlyToPos(Vector3 Enemy)
    {
        base.FlyToPos(Enemy);
    }

}

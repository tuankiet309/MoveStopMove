using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class CONSTANT_VALUE : MonoBehaviour
{
    ////////////////INFORMATION/////////////////
    public const int FIRST_SCORE_MILESTONE = 2;
    public const int SCORE_MILESTONE_INCREASER = 3;
    ///////////////DETECT CIRCLE///////////////
    public const float FIRST_CIRCLE_RADIUS = 5;
    public const float CIRCLE_RADIUS_INCREASER = 1.5f;
    public const float BODY_SCALER_INCREASER = 0.05F;
    //////////////MOVEMENT_INFO/////////////////
    public const float FIRST_MOVESPEED = 8f;
    public const float FIRST_MOVESPEED_ENEMY = 6f;
    public const float FIRST_ROTATIONSPEED = 15F;


    /////////////WEAPON_ATTR/////////////////
    public const float FIRST_DELAYED_ATTACK = 5f;
    public const float PROJECTILE_FLY_SPEED = 9f;
    public const float PROJECTILE_ROTATE_SPEED = 3f;
    public const float DISTANCE_TIL_COMBACK = 0.5f;

    /////////////DECOR//////////////////////
    public const float DECORATION_TRANPARENT_VALUE = 0.2F;

    //////////////MONSTER POOL////////////////
    public const int MAXIMUM_ENEMY_POOL = 20;
    public const int LEAST_ENEMY_POOL = 10;




    ///////////CAMERA///////////////////////////
    public const float CAMERA_OFFSET_INCREASE = 10f;
    public static readonly OFFSETFORCAMERA OFFSETWHENINPVP = new OFFSETFORCAMERA(
        new Vector3(0.200000003f, 18.6200008f, -15.0600004f),
        new Vector3(43.58778f, 0, 0)
    );

    public static readonly OFFSETFORCAMERA OFFSETWHENHALL = new OFFSETFORCAMERA(
        new Vector3(0, 3.9000001f, -8.02999973f),

        new Vector3(20.4000015f, 0, 0)
     );
}


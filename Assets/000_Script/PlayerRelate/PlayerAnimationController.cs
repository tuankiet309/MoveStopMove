using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private PlayerMovementController playerMovementController;
    [SerializeField] private PlayerAttacker attacker;
    private void Start()
    {
        if (playerMovementController == null)
            return;
        playerMovementController.onPlayerMoving += UpdateMoveAnimation;
    }
    private void UpdateMoveAnimation(bool isMoving)
    { 
        anim.SetBool("isMoving",isMoving);
    }
    private void UpdateAttack()
    {

    }

}

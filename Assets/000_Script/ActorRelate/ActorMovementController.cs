using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorMovementController : MonoBehaviour
{
    [SerializeField] private Stick moveStick;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private ActorAttacker attacker;
    private float rotateSpeed;
    private float moveSpeed;

    private Vector3 moveVelocity = Vector3.zero;
    private Vector3 rotateDir = Vector3.zero;

    public delegate void OnActorMoving(Vector3 moveVec);
    public event OnActorMoving onActorMoving;

    private void Awake()
    {
        rotateSpeed = CONSTANT_VALUE.FIRST_ROTATIONSPEED;
        moveSpeed = CONSTANT_VALUE.FIRST_MOVESPEED;
    }
    private void OnEnable()
    {
        if (moveStick != null)
            moveStick.onThumbstickValueChanged.AddListener(moveStickInputHandler);
        if(attacker != null) 
            attacker.onHaveTarget += RotateToTarget;
    }
    private void OnDisable()
    {
        if (moveStick != null)
            moveStick.onThumbstickValueChanged.RemoveListener(moveStickInputHandler);
        if (attacker != null)
            attacker.onHaveTarget -= RotateToTarget;
    }

    private void Update()
    {
        
            rb.velocity = new Vector3(moveVelocity.x, rb.velocity.y, moveVelocity.z);
        if(rotateDir != Vector3.zero)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(rotateDir), rotateSpeed * Time.deltaTime);
        
    }

    private void moveStickInputHandler(Vector2 inputValue)
    {
        float x = inputValue.x;
        float z = inputValue.y;
        moveVelocity = new Vector3(x, 0, z).normalized * moveSpeed;
        rotateDir = inputValue == Vector2.zero ? rotateDir : new Vector3(x, 0, z);
        onActorMoving?.Invoke(moveVelocity);
    }

    protected virtual void RotateToTarget(GameObject target)
    {
        if (moveVelocity == Vector3.zero && target != null)
        {   Vector3 roteToDir = target.transform.position - transform.position;
            rotateDir = new Vector3(roteToDir.x, rotateDir.y, roteToDir.z);
        };
    }

}
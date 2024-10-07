using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private Joystick moveStick;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody rb;
    private Vector3 moveVelocity = Vector3.zero;

    public delegate void OnPlayerMoving(bool isMoving);
    public event OnPlayerMoving onPlayerMoving;

    private void Start()
    {
        moveStick.onThumbstickValueChanged += InputHandler;
    }
    void Update()
    {
        rb.velocity = new Vector3(moveVelocity.x , rb.velocity.y, moveVelocity.y);
        
    }
    private void InputHandler(Vector2 inpulValue, bool isTap)
    {
        
        moveVelocity = inpulValue.normalized * moveSpeed;
        if(inpulValue == Vector2.zero && !isTap)
        {
            onPlayerMoving?.Invoke(false);
            Debug.Log("I Stop");
        }
        else
        {
            onPlayerMoving?.Invoke(true);
            Debug.Log("I Move");
        }
    }


}

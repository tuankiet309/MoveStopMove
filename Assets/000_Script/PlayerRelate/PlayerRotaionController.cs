using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotaionController : MonoBehaviour
{
    [SerializeField] Joystick moveStick;
    [SerializeField] PlayerAttacker attacker;
    [SerializeField] float rotationSpeed;
    Vector3 rotateDir = Vector3.zero;
    // Start is called before the first frame update

    private void Start()
    {
        if(moveStick == null || attacker == null)
            return;
        moveStick.onThumbstickValueChanged += InputHandler;
        attacker.onPlayerAttack += InputHandler;
    }

    private void InputHandler(Vector2 inputValue, bool isTap)
    {
        float x = inputValue.x;
        float z = inputValue.y;
        if (inputValue == Vector2.zero)
            return;
        rotateDir = new Vector3(x, 0, z).normalized;
        
    }
    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(rotateDir),rotationSpeed * Time.deltaTime);
    }
}

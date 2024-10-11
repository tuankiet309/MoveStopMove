using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform CameraFollow;  
    [SerializeField] private Transform CameraArm;  
    [SerializeField] private float followSpeed = 5f; 
    [SerializeField] private float rotationSpeed = 5f;  

    private Transform playerTransform;  
    public static CameraController instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void OnEnable()
    {
        GameManager.Instance.onStateChange.AddListener(UpdateCameraPosToGameState);
        UpdateCameraPosToGameState(Enum.GameState.Hall);
    }


    void LateUpdate()
    {
        if (playerTransform == null)
            return;
        CameraFollow.position = playerTransform.position + CONSTANT_VALUE.OFFSETWHENINPVP.OSposition;
        CameraArm.rotation = Quaternion.Euler(CONSTANT_VALUE.OFFSETWHENINPVP.OSrotation);
    }

    private void UpdateCameraPosToGameState(Enum.GameState gameState)
    {
        if (gameState == Enum.GameState.Hall)
        {
            CameraFollow.position = CONSTANT_VALUE.OFFSETWHENHALL.OSposition;
            CameraArm.rotation = Quaternion.Euler(CONSTANT_VALUE.OFFSETWHENHALL.OSrotation);
        }
        else if (gameState == Enum.GameState.NormalPVP)
        {
            playerTransform = Player.Instance.transform;
        }
    }
    private void FollowPlayer()
    {
        if (playerTransform == null) return;

        Vector3 targetPosition = playerTransform.position + CONSTANT_VALUE.OFFSETWHENINPVP.OSposition;
        CameraFollow.position = Vector3.Lerp(CameraFollow.position, targetPosition, followSpeed * Time.deltaTime);
        Quaternion targetRotation = Quaternion.Euler(CONSTANT_VALUE.OFFSETWHENINPVP.OSrotation);
        CameraArm.rotation = Quaternion.Slerp(CameraArm.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}

public class OFFSETFORCAMERA
{
    public Vector3 OSposition;
    public Vector3 OSrotation;

    public OFFSETFORCAMERA(Vector3 position, Vector3 rotation)
    {
        this.OSposition = position;
        this.OSrotation = rotation;
    }
}

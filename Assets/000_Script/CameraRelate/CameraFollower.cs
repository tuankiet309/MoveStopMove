using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float offSet;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(player.position.x, transform.position.y, player.position.z + offSet);
    }
}

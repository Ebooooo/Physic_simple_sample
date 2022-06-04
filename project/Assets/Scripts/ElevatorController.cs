using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    [SerializeField]
    private Transform elevatorPlatform;
    private Vector3 startPos;
    private Vector3 endPos;
    public float speed = 0.1f;

    private void Start()
    {
        startPos = elevatorPlatform.position;
        endPos = new Vector3(elevatorPlatform.position.x, elevatorPlatform.position.y + 10f, elevatorPlatform.position.z);
    }
    private void Update()
    {
        elevatorPlatform.position = Vector3.Lerp(startPos, endPos, Mathf.PingPong(Time.time * speed, 1.0f));
    }
}   



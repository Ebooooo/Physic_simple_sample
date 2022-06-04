

using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour
{
    public Vector3 FloorDistance = new Vector3(0,10,0);
    public float Speed = 1.0f;
    private int Floor = 0;
    private int MaxFloor = 1;
    public Transform moveTransform;

    private float tTotal;
    private bool isMoving;
    private float moveDirection;


    void Start()
    {
        moveTransform = moveTransform ?? transform;
    }

    void Update()
    {
        if (isMoving)
        {
            MoveElevator();
        }
    }

    void MoveElevator()
    {
        var v = moveDirection * FloorDistance.normalized * Speed;
        var t = Time.deltaTime;
        var tMax = FloorDistance.magnitude / Speed;
        t = Mathf.Min(t, tMax - tTotal);
        moveTransform.Translate(v * t);
        tTotal += t;

        if (tTotal >= tMax)
        {
            isMoving = false;
            tTotal = 0;
            Floor += (int)moveDirection;
        }
    }

    public void StartMoveUp()
    {
        if (isMoving)
            return;

        isMoving = true;
        moveDirection = 1;
    }

    public void StartMoveDown()
    {
        if (isMoving)
            return;

        isMoving = true;
        moveDirection = -1;
    }

    public void CallElevator()
    {
        if (isMoving)
            return;


        if (Floor < MaxFloor)
        {
            StartMoveUp();
        }
        else
        {
            StartMoveDown();
        }

    }
}
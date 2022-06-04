using UnityEngine;
using System.Collections;

public class ElevatorButton : MonoBehaviour
{
    public Elevator Elevator;

    void OnTriggerEnter(Collider collider)
    {
        var go = collider.gameObject;
        var player = go.GetComponent<PlayerController>();

        if (player != null && Elevator != null)
        {
            Elevator.CallElevator();
        }
    }
}

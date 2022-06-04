using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    private Transform pickedUpObject;
    private Vector3 lastPosition;
    private void Update()
    {
        Ray ray = new Ray(transform.position + Vector3.up, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction, Color.black);
        if (Input.GetMouseButtonDown(0))
        {
            if (pickedUpObject)
                pickedUpObject = null;

            RaycastHit hit;
            if(Physics.Raycast(ray,out hit,1.0f))
            {
                pickedUpObject = hit.transform;
            }
        }

        if (pickedUpObject)
        {
            pickedUpObject.transform.position += transform.position - lastPosition;
        }

        lastPosition = transform.position;
    }

}

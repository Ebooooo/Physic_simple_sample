using System.Collections;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    void OnMouseDown()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
        GetComponent<Rigidbody>().useGravity = true;
    }
}
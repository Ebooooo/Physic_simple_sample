using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMove : MonoBehaviour

{
public GameObject moveplatform;

private void OnTriggerStay()
{
	moveplatform.transform.position += moveplatform.transform.up * Time.deltaTime;
}
}  
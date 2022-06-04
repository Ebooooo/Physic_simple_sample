using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private List<GameObject> feets;
    [SerializeField]
    private Rigidbody mainRigidbody;
    [SerializeField]
    private float jumpForce = 5f;
    [Range(1f, 100f)]
    [SerializeField]
    float movementSpeed = 5.0f;
    [SerializeField]
    public float rotationSpeed = 1.0f;

    private List<Collider> feetsColliders = new List<Collider>();
    private Rigidbody[] rb;
    private bool isControllable = true;
    private bool isOnTheGround = true;
    private bool wasPressedBefore = false;

    void Awake()
    {
        foreach (var feet in feets)
        {
            feetsColliders.Add(feet.GetComponent<Collider>());
            
        }
    }

    void Update()
    {
        var speed = Input.GetButton("Shift") ? 1.5f : 1f;
        var verticalInput = Input.GetAxis("Vertical");

        transform.Translate(0, 0, verticalInput * Time.deltaTime * (movementSpeed + speed));
        transform.Rotate(0, Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f * rotationSpeed, 0);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(wasPressedBefore){
            wasPressedBefore=false;
            isOnTheGround=true;
            }
            else{
             isOnTheGround=false;
            mainRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            wasPressedBefore = true;  
			}
        }

        HandleAnimations(verticalInput,speed);
    }

    void HandleAnimations(float verticalInput, float speed)
    {
        animator.SetBool("run", verticalInput > 0 && isOnTheGround);
        animator.SetFloat("speed", speed);
        animator.SetBool("jump", !isOnTheGround);
    }
void OnTriggerEnter(Collider other) {
    isOnTheGround = true;      
}


}

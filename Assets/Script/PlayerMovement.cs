using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;
    public Vector3 input;
    public bool canMove = true;
    public float moveAcceleration = 50.0f;
    public float moveDeacceleration = 0.1f;
    public float maxVelocity = 5.0f;
    public bool noLimit = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        anim.SetFloat("HInput", Input.GetAxis("Horizontal"));
    }
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(input.x, 0, input.z).normalized;
        rb.AddForce(movement * moveAcceleration);

        if (input.magnitude > 0 && canMove)
        {
            rb.AddForce(movement * moveAcceleration);
        }
        else
        {
            Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
            rb.AddForce(-flatVel * moveDeacceleration);
        }

        Vector3 horizontalVel = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
        if (horizontalVel.magnitude > maxVelocity && !noLimit)
        {
            Vector3 cap = horizontalVel.normalized * maxVelocity;
            rb.linearVelocity = new Vector3(cap.x, rb.linearVelocity.y, cap.z);
        }

        
    }      
}

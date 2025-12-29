using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Rigidbody rb;
    private Vector3 playerVelocity;
    private float gravityValue = Physics.gravity.y;
    private float InputV;
    private float InputH;
    private bool canMove = true;
    public float moveAcceleration = 50.0f;
    public float moveDeacceleration = 0.1f;
    public float maxVelocity = 5.0f;
    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        rb = gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
        InputH = Input.GetAxis("Horizontal");
        InputV = Input.GetAxis("Vertical");
    }
    void FixedUpdate()
    {
        if(canMove)rb.AddForce(new Vector3(InputH, 0 , InputV) * moveAcceleration);
        if (rb.linearVelocity.magnitude > maxVelocity)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxVelocity;
        }
        if (InputH == 0 && InputV == 0)
        {
            rb.linearVelocity = Vector3.Lerp(rb.linearVelocity, Vector3.zero, moveDeacceleration);
        }
    }
}

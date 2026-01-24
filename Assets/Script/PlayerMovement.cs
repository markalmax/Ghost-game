using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Rigidbody rb;
    private Vector3 playerVelocity;
    private float gravityValue = Physics.gravity.y;
    public Vector2 input;
    public bool canMove = true;
    public float moveAcceleration = 50.0f;
    public float moveDeacceleration = 0.1f;
    public float maxVelocity = 5.0f;
    public bool noLimit = false;
    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        rb = gameObject.GetComponent<Rigidbody>();
        rb.maxLinearVelocity = maxVelocity;
    }
    void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");
    }
    void FixedUpdate()
    {
        if(canMove)rb.AddForce(new Vector3(input.x, 0 , input.y) * moveAcceleration);
        if (input.x == 0 && input.y == 0)
        {
            rb.linearVelocity = new Vector3(
                Mathf.Lerp(rb.linearVelocity.x, 0, moveDeacceleration),
                rb.linearVelocity.y,
                Mathf.Lerp(rb.linearVelocity.z, 0, moveDeacceleration)
            );
        }
    }
}

using UnityEngine;

public class Jumping : MonoBehaviour
{
    public float jumpForce = 50f;
    public Rigidbody rb;
    public float cd = 0.5f;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    public void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    public void UseSkill(int skillId)
    {
        Jump();
    }
}

using UnityEngine;
[CreateAssetMenu(menuName ="Ability/Jump")]
public class Jumping : Ability
{
    public float jumpForce = 50f;
    public Rigidbody rb;
    public override void UseSkill(GameObject player)
    {
        rb = player.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    public override void EndSkill(GameObject player)
    {
        
    }
    public override bool KeepActive(GameObject player)
    {
        return !Physics.Raycast(rb.transform.position, Vector3.down, 1.1f);
    }
}

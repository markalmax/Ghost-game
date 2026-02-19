using UnityEngine;
[CreateAssetMenu(menuName ="Ability/Jump")]
public class Jumping : Ability
{
    public float jumpForce = 50f;
    public Rigidbody rb;
    public AudioSource ass;
    public AudioClip sound;
    public override void UseSkill(GameObject player)
    {
        rb = player.GetComponent<Rigidbody>();
        ass = player.GetComponent<AudioSource>();
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        ass.clip = sound;
        ass.pitch = Random.Range(0.8f, 1.2f);
        ass.Play();
    }
    public override void EndSkill(GameObject player)
    {
        
    }
    public override bool KeepActive(GameObject player)
    {
        return !Physics.Raycast(rb.transform.position, Vector3.down, 1.1f);
    }
}

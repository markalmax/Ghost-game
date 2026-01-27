using System.Collections;
using UnityEngine;
using UnityEngine.TextCore.Text;
[CreateAssetMenu(menuName ="Ability/Dashing")]

public class Dashing : Ability
{
    PlayerMovement pm;
    Rigidbody rb;
    TrailRenderer tr;
    AudioSource ass;
    public float dashDistance = 10f;
    public float dashVelocity = 10f;
    public AudioClip sound;
    LayerMask wall;
        public override void UseSkill(GameObject player)
    {
        pm = player.GetComponent<PlayerMovement>();
        rb = player.GetComponent<Rigidbody>();
        tr = player.GetComponent<TrailRenderer>();
        ass = player.GetComponent<AudioSource>();

        wall = LayerMask.NameToLayer("Wall");
        tr.emitting = true;
        pm.canMove = false; 
        pm.noLimit = true;
        Physics.IgnoreLayerCollision(player.layer, wall, true);
        Vector3 dashDirection = new Vector3(pm.input.x, 0, pm.input.y).normalized;
        rb.linearVelocity = dashDirection * dashVelocity;
        ass.clip = sound;
        ass.pitch = Random.Range(0.8f, 1.2f);
        ass.Play();
    }
    public override void EndSkill(GameObject player)
    {
        pm = player.GetComponent<PlayerMovement>();
        rb = player.GetComponent<Rigidbody>();
        tr = player.GetComponent<TrailRenderer>();
        pm.canMove = true;
        pm.noLimit = false;
        Physics.IgnoreLayerCollision(player.layer, wall, false);
        tr.emitting = false;
    }
}

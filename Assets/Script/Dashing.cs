using System.Collections;
using UnityEngine;
using UnityEngine.TextCore.Text;
[CreateAssetMenu(menuName ="Ability/Dashing")]

public class Dashing : Ability
{
    PlayerMovement pm;
    Rigidbody rb;
    TrailRenderer tr;
    public float dashDistance = 10f;
    public float dashVelocity = 10f;
    public float maxDashVelocity;
    public float OGMaxVelocity;
    LayerMask wall;
    public override void UseSkill(GameObject player)
    {
        pm = player.GetComponent<PlayerMovement>();
        rb = player.GetComponent<Rigidbody>();
        tr = player.GetComponent<TrailRenderer>();
        maxDashVelocity = dashVelocity;
        wall = LayerMask.NameToLayer("Wall");
        tr.emitting = true;
        pm.canMove = false; rb.maxLinearVelocity = maxDashVelocity;
        Physics.IgnoreLayerCollision(player.layer, wall, true);
        Vector3 dashDirection = new Vector3(pm.input.x, 0, pm.input.y).normalized;
        rb.linearVelocity = dashDirection * dashVelocity;
        
    }
    public override void EndSkill(GameObject player)
    {
        pm = player.GetComponent<PlayerMovement>();
        rb = player.GetComponent<Rigidbody>();
        tr = player.GetComponent<TrailRenderer>();
        pm.canMove = true;
        rb.maxLinearVelocity = OGMaxVelocity;
        Physics.IgnoreLayerCollision(player.layer, wall, false);
        tr.emitting = false;
    }
}

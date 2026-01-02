using System.Collections;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Dashing : MonoBehaviour
{
    public PlayerMovement pm;
    public Rigidbody rb;
    public TrailRenderer tr;
    public float dashDistance = 10f;
    public float dashVelocity = 10f;
    public float cd = 2f;
    private float maxDashVelocity;
    private float OGMaxVelocity;
    public string wallLayerName = "Wall";
    private int wallLayer = -1;
    void Start()
    {
        pm = gameObject.GetComponent<PlayerMovement>();
        rb = gameObject.GetComponent<Rigidbody>();
        tr = gameObject.GetComponent<TrailRenderer>();
        maxDashVelocity = dashVelocity;
        OGMaxVelocity = pm.maxVelocity;
        wallLayer = LayerMask.NameToLayer(wallLayerName);
    }
    void Update()
    {
        
    }
    public void Dash()
    {
        tr.emitting = true;
        pm.canMove = false; pm.maxVelocity = maxDashVelocity;
        if (wallLayer != -1)
        {
            Physics.IgnoreLayerCollision(gameObject.layer, wallLayer, true);
        }
        Vector3 dashDirection = new Vector3(pm.InputH, 0, pm.InputV).normalized;
        rb.linearVelocity = dashDirection * dashVelocity;
        StartCoroutine(EndDash());
    }
    public IEnumerator EndDash()
    {
        yield return new WaitForSeconds(dashDistance / dashVelocity);
        pm.canMove = true;
        pm.maxVelocity = OGMaxVelocity;
        if (wallLayer != -1)
        {
            Physics.IgnoreLayerCollision(gameObject.layer, wallLayer, false);
        }
        tr.emitting = false;
    }
    public void UseSkill(int skillId)
    {
        Dash();
    }
}

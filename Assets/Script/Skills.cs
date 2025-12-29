using System.Collections;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Skills : MonoBehaviour
{
    public PlayerMovement pm;
    public Rigidbody rb;
    public TrailRenderer tr;
    public float dashDistance = 10f;
    public float dashSpeed = 10f;
    public float dashCooldown = 2f;
    public float dashTimer = 0f;
    private float maxDashVelocity;
    private float OGMaxVelocity;
    public string wallLayerName = "Wall";
    private int wallLayer = -1;
    void Start()
    {
        pm = gameObject.GetComponent<PlayerMovement>();
        rb = gameObject.GetComponent<Rigidbody>();
        tr = gameObject.GetComponent<TrailRenderer>();
        maxDashVelocity = dashSpeed;
        OGMaxVelocity = pm.maxVelocity;
        wallLayer = LayerMask.NameToLayer(wallLayerName);
    }
    void Update()
    {
        dashTimer -= Time.deltaTime;
        if(Input.GetButtonDown("Fire1"))
        {
            if(dashTimer <= 0f)Dash();
        }
    }
    void Dash()
    {
        tr.emitting = true;
        pm.canMove = false; pm.maxVelocity = maxDashVelocity;
        if (wallLayer != -1)
        {
            Physics.IgnoreLayerCollision(gameObject.layer, wallLayer, true);
        }
        Vector3 dashDirection = new Vector3(pm.InputH, 0, pm.InputV).normalized;
        rb.linearVelocity = dashDirection * dashSpeed;
        dashTimer = dashCooldown;
        StartCoroutine(EndDash());
    }
    public IEnumerator EndDash()
    {
        yield return new WaitForSeconds(dashDistance / dashSpeed);
        pm.canMove = true;
        pm.maxVelocity = OGMaxVelocity;
        if (wallLayer != -1)
        {
            Physics.IgnoreLayerCollision(gameObject.layer, wallLayer, false);
        }
        tr.emitting = false;
    }
}

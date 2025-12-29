using UnityEngine;
using UnityEngine.TextCore.Text;

public class Skills : MonoBehaviour
{
    public CharacterController controller;
    public float dashDistance = 5f;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        if(Input.GetAxis("Fire1")>0)
        {
            Dash();
        }
    }
    void Dash()
    {
        print("Dash");
        Vector3 dashVector = Input.GetAxis("Horizontal") * transform.right * dashDistance + Input.GetAxis("Vertical") * transform.forward * dashDistance;
        controller.Move(dashVector * Time.deltaTime);
    }
}

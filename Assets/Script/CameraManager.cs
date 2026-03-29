using Unity.Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]CinemachineCamera CC;

    void OnCollisionEnter(Collision collision)
    {
        
    }
    void OnCollisionExit(Collision collision)
    {
        if(CC != null)
        {
            CC.enabled = false;
        }
    }
    void OnCollisionStay(Collision collision)
    {
        if(collision.transform.parent.GetComponentInChildren<CinemachineCamera>() != null)
        {
            CC = collision.transform.parent.GetComponentInChildren<CinemachineCamera>();

            CC.Follow = FindAnyObjectByType<PlayerMovement>().transform;
            CC.enabled = true;
        }
    }
}

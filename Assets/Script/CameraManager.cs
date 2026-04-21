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
        if (collision.transform == null)return;
        if (collision.transform.GetComponentInChildren<CinemachineCamera>() == null)return;

        CC = collision.transform.GetComponentInChildren<CinemachineCamera>();
        CC.Follow = gameObject.transform;
        CC.enabled = true;
    }
}

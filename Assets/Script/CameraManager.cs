using Unity.Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] CinemachineCamera CC;

    void OnCollisionEnter(Collision collision)
    {
    }

    void OnCollisionExit(Collision collision)
    {
        if (CC != null)
        {
            CC.enabled = false;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.transform == null)
        {
            return;
        }

        var parentTransform = collision.transform.parent;
        if (parentTransform == null)
        {
            return;
        }

        CinemachineCamera targetCamera = null;
        foreach (var cam in parentTransform.GetComponentsInChildren<CinemachineCamera>())
        {
            if (cam.transform != parentTransform)
            {
                targetCamera = cam;
                break;
            }
        }

        if (targetCamera == null)
        {
            return;
        }

        CC = targetCamera;
        CC.Follow = gameObject.transform;
        CC.enabled = true;

    }
}

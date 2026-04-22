using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    [SerializeField] private float hoverSpeed = 2f;
    [SerializeField] private float hoverAmplitude = 0.5f;
    [SerializeField] private float rotationSpeedX = 30f;
    [SerializeField] private float rotationSpeedZ = 20f;

    private float originalY;

    void Start()
    {
        originalY = transform.localPosition.y;
    }

    void Update()
    {
        // Hovering up and down
        float hoverOffset = Mathf.Sin(Time.time * hoverSpeed) * hoverAmplitude;
        transform.localPosition = new Vector3(transform.localPosition.x, originalY + hoverOffset, transform.localPosition.z);

        // Rotating around X and Z axes
        transform.Rotate(Vector3.right, rotationSpeedX * Time.deltaTime);
        transform.Rotate(Vector3.forward, rotationSpeedZ * Time.deltaTime);
    }
}

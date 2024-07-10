using UnityEngine;

public class CameraSway : MonoBehaviour
{
    // Amplitude of the sway (how far the camera moves)
    public float swayAmplitude = 0.5f;
    // Speed of the sway (how fast the camera moves)
    public float swaySpeed = 1.0f;

    // Original position of the camera
    private Vector3 initialPosition;

    void Start()
    {
        // Save the initial position of the camera
        initialPosition = transform.localPosition;
    }

    void Update()
    {
        // Calculate the sway offset
        float swayOffset = Mathf.Sin(Time.time * swaySpeed) * swayAmplitude;

        // Apply the sway offset to the camera's position
        transform.localPosition = initialPosition + new Vector3(swayOffset, 0, 0);
    }
}

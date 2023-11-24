using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCameraController : MonoBehaviour
{
    public float sensitivity = 2f;
    public float maxVerticalAngle = 80f;
    public Transform playerTransform;

    private Vector2 lookInput;

    private void Update()
    {
        lookInput = Mouse.current.delta.ReadValue();

        
        lookInput *= sensitivity * 0.05f;

        
    }

    
}

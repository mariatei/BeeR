using UnityEngine;
using static OVRInput;

public class XRPlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;

    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>(); // Zugriff auf den CharacterController des GameObjects
    }

    void Update()
    {
        Vector2 axis = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

        // Bewegung basierend auf dem linken Joystick (X- und Z-Achse für Vorwärts, Rückwärts, Links, Rechts)
        Vector3 moveDirection = transform.forward * axis.y + transform.right * axis.x;
        characterController.Move(moveDirection * speed * Time.deltaTime);

        // Tasten für vertikale Bewegung (Hoch, Runter)
        if (OVRInput.Get(OVRInput.Button.One)) 
        {
            characterController.Move(Vector3.up * speed * Time.deltaTime);
        }
        if (OVRInput.Get(OVRInput.Button.Two)) 
        {
            characterController.Move(Vector3.down * speed * Time.deltaTime);
        }
    }
}
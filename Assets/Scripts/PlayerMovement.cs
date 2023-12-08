using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Geschwindigkeit der Bewegung des Spielers
    public float rotationSpeed = 3.0f; // Geschwindigkeit der Rotation des Spielers

    void Update()
    {
        // Eingaben von den Pfeiltasten
        float horizontalMove = Input.GetAxis("Horizontal"); // Pfeiltasten links/rechts
        float verticalMove = Input.GetAxis("Vertical"); // Pfeiltasten hoch/runter

        // Bewegung des Spielers basierend auf den Pfeiltasten
        Vector3 moveDirection = new Vector3(horizontalMove, 0.0f, verticalMove) * moveSpeed * Time.deltaTime;
        transform.Translate(moveDirection, Space.Self);

        // Rotation des Spielers basierend auf den Pfeiltasten
        if (horizontalMove != 0 || verticalMove != 0)
        {
            float targetAngle = Mathf.Atan2(horizontalMove, verticalMove) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, targetAngle, 0);
        }
    }
}


using UnityEngine;
using UnityEngine.InputSystem;

public class Shmovement : MonoBehaviour
{
    public float playerSpeed = 6;
    public float lateralPlayerSpeed = 4;

    private Vector2 movementInput;

    // Called when the player moves
    public void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }

    void Update()
    {
        // Forward movement
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.World);

        // Lateral movement
        if (movementInput.x < 0) // A key or left
        {
            transform.Translate(Vector3.left * Time.deltaTime * lateralPlayerSpeed, Space.World);
        }
        if (movementInput.x > 0) // D key or right
        {
            transform.Translate(Vector3.right * Time.deltaTime * lateralPlayerSpeed, Space.World);
        }
    }
}

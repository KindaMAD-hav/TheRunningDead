using UnityEngine;

public class Shmovement : MonoBehaviour
{
    public float playerSpeed = 6;
    public float lateralPlayerSpeed = 4;


    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.World);
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * lateralPlayerSpeed);
        }
        if (Input.GetKey(KeyCode.D)){

            transform.Translate(Vector3.right * Time.deltaTime * lateralPlayerSpeed * -1);
        }
    }
}

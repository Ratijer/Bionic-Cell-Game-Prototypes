using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public float rotationSpeed;
    public bool rotate;   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rotate)
        {
            PlayerRotation();
        }
        else
        {
            PlayerMovement();
        }
    }

    private void PlayerMovement()
    {
        // Vertical: Up/Down-Arrow, or WS-keys
        transform.position += Input.GetAxis("Vertical") * transform.up *
                                    (movementSpeed * Time.smoothDeltaTime);
        // Horizontal: Left/Right-Arrow, or AD-Keys
        transform.position += Input.GetAxis("Horizontal") * transform.right *
                                    (movementSpeed * Time.smoothDeltaTime);
    }

    private void PlayerRotation()
    {
        //Rotation
        if (Input.GetMouseButton(0)) //Left
        {
            transform.Rotate(new Vector3(0f, 0f, rotationSpeed) * Time.deltaTime);
        }
        if (Input.GetMouseButton(1)) //Right
        {
            transform.Rotate(new Vector3(0f, 0f, -rotationSpeed) * Time.deltaTime);
        }
    }
}

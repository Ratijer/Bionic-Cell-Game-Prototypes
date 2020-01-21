using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public delegate void VoidWithNoArguments();
    //public event VoidWithNoArguments AttackEvent;

    public float movementSpeed;
    public float rotationSpeed;
    public bool rotate;
    public float playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rotate)
        {
            PlayerRotation();   //Cell object (under the player object) will rotate independly of the player object's movement
        }
        else
        {
            PlayerMovement();   
        }

        if (gameObject.name == "BionicCell")
        {
             
        }
    }

    //Take damage from colliding into enemies or projectiles
    private void OnTriggerEnter2D(Collider2D enemyDamage)     
    {
        //For testing only
        if (enemyDamage.name == "OuchCube")
            TakeDamage(enemyDamage.GetComponent<OuchCubeTest>().damage);
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("Player was hit!");
        playerHealth -= damage;
        Debug.Log("Player Health: " + playerHealth);
        if (playerHealth <= 0)
        {
            Debug.Log("Player has died");
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
        if (Input.GetButton("Fire1")) //Left
        {
            transform.Rotate(new Vector3(0f, 0f, rotationSpeed) * Time.deltaTime);
        }
        if (Input.GetButton("Fire2")) //Right
        {
            transform.Rotate(new Vector3(0f, 0f, -rotationSpeed) * Time.deltaTime);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //[SerializeField]
    //private float _speed = 5.0f;
    //[SerializeField]
    //private float _fireRate = 0.25f;

    //private float _nextFire = 0.0f;

    //public delegate void VoidWithNoArguments();
    //public event VoidWithNoArguments AttackEvent;

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

        if (gameObject.name == "BionicCell")
        {
            //if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
            //{
            //    Shoot();
            //}

            //RemoveItems();
        }
    }

    //public void EquipItem(ItemBehavior item)
    //{
    //    if (item.weaponSOAsset.weaponScriptName != null && item.weaponSOAsset.weaponScriptName != "")
    //    {
    //        WeaponEffect weaponEffect = System.Activator.CreateInstance(System.Type.GetType(item.weaponSOAsset.weaponScriptName), new System.Object[] { this, item }) as WeaponEffect;
    //        weaponEffect.RegisterEventEffect();
    //    }
    //}

    //private void RemoveItems()  //For testing purposes only
    //{
    //    if (Input.GetKeyDown(KeyCode.R))
    //    {
    //        if (AttackEvent != null)
    //        {
    //            foreach (Delegate d in AttackEvent.GetInvocationList())
    //            {
    //                AttackEvent -= (VoidWithNoArguments)d;
    //            }
    //        }
    //    }
    //}

    //private void Shoot()
    //{
    //    if (Time.time > _nextFire)
    //    {
    //        if (AttackEvent != null)
    //        {
    //            AttackEvent.Invoke();
    //        }
    //        _nextFire = Time.time + _fireRate;
    //    }
    //}

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

﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortBehavior : MonoBehaviour
{
    //private float _fireRate = 0.25f;

    //private float _nextFire = 0.0f;

    public delegate void VoidWithNoArguments();
    public event VoidWithNoArguments AttackEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }

        RemoveItems();
    }

    public void EquipItem(ItemBehavior item)
    {
        if (item.weaponSOAsset.weaponScriptName != null && item.weaponSOAsset.weaponScriptName != "")
        {
            WeaponEffect weaponEffect = System.Activator.CreateInstance(System.Type.GetType(item.weaponSOAsset.weaponScriptName), new System.Object[] { this, item }) as WeaponEffect;
            weaponEffect.RegisterEventEffect();
        }
    }

    private void RemoveItems()  //For testing purposes only
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (AttackEvent != null)
            {
                foreach (Delegate d in AttackEvent.GetInvocationList())
                {
                    AttackEvent -= (VoidWithNoArguments)d;
                }
            }
        }
    }

    private void Shoot()
    {
        //if (Time.time > _nextFire)
        //{
        //    if (AttackEvent != null)
        //    {
        //        AttackEvent.Invoke();
        //    }
        //    _nextFire = Time.time + _fireRate;
        //}
    }
}

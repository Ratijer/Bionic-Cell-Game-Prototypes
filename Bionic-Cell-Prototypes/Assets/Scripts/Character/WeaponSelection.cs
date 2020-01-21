﻿//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class WeaponSelection : MonoBehaviour
{
    public int selectedWeapon;

    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SelectWeapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if(i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }

        }
    }
}

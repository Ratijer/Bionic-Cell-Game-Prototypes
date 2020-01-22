//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class WeaponSelection : MonoBehaviour
{
    private WeaponControl weaponControl = WeaponControl.FireOne;
    enum WeaponControl
    {
        FireAll,    //Fire all weapons at once
        FireOne     //Fire only one weapon
    }

    public static WeaponSelection instance;
    public int selectedWeapon;
    public float abilityMeterFill = 0;   //Starts at 0. When at 100, player can fire all weapons at once
    public float abilityTime = 100;

    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFSM();

        if (Input.GetKey(KeyCode.Q) && abilityMeterFill >= 100)
        {
            weaponControl = WeaponControl.FireAll;
        }
    }

    public void AddToAbilityMeter(float value)
    {
        if(abilityMeterFill < 100)
        {
            abilityMeterFill += value;
        }
    }

    //Finite state machine
    public void UpdateFSM()
    {
        switch (weaponControl)
        {
            case WeaponControl.FireOne:
                WeaponScrollControl();
                break;
            case WeaponControl.FireAll:
                FireAllWeapons();
                break;
        }
    }

    //All weapons will be selected and will be able to activate all at the same time 
    private void FireAllWeapons()
    {
        if (abilityMeterFill > 0)
        {
            foreach (Transform weapon in transform)
            {
                //weapon.gameObject.SetActive(true);
                weapon.GetComponent<WeaponBehavior>().SetSpriteSelected(true);
            }

            //The numer 1000 is for testing purposes only
            abilityMeterFill -= 1000 / abilityTime * Time.deltaTime;   //Meter gradually goes down
        }
        else //Ability ends when meter is at 0
        {
            foreach (Transform weapon in transform)
            {
                //weapon.gameObject.SetActive(true);
                weapon.GetComponent<WeaponBehavior>().SetSpriteSelected(false);
            }
            weaponControl = WeaponControl.FireOne;
            abilityMeterFill = 0;   //Make sure meter is at 0 and not in the negatives
        }
    }

    private void WeaponScrollControl()
    {
        int previousSelectedWeapon = selectedWeapon;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= transform.childCount - 1)
            {
                selectedWeapon = 0;
            }
            else
            {
                selectedWeapon++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
            {
                selectedWeapon = transform.childCount - 1;
            }
            else
            {
                selectedWeapon--;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            selectedWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            selectedWeapon = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
        {
            selectedWeapon = 3;
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
    }

    private void SelectWeapon()
    {
        int i = 0;
        if(transform != null)
        {
            //if (transform.childCount == 1)
            //{
            //    transform.GetChild(0).GetComponent<WeaponBehavior>().SetSpriteSelected(true);
            //}
            //else
            //{
                foreach (Transform weapon in transform)
                {
                    if (i == selectedWeapon)
                    {
                        //weapon.gameObject.SetActive(true);
                        weapon.GetComponent<WeaponBehavior>().SetSpriteSelected(true);
                    }
                    else
                    {
                        //weapon.gameObject.SetActive(true);
                        weapon.GetComponent<WeaponBehavior>().SetSpriteSelected(false);
                    }
                    i++;
                }
            //}
        }
    }

    public void AddWeapon(GameObject weapon)
    {
        //GO weapon becomes child of the weapons object
        // Sets "newParent" as the new parent of the child GameObject.
        weapon.transform.SetParent(transform);
    }
}

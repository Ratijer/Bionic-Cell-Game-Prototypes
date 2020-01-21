//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class WeaponSelection : MonoBehaviour
{
    public static WeaponSelection instance;
    public int selectedWeapon;

    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;

        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if(selectedWeapon >= transform.childCount - 1)
            {
                selectedWeapon = 0;
            }
            else
            {
                selectedWeapon++;
            }
        }
        if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if(selectedWeapon <= 0)
            {
                selectedWeapon = transform.childCount - 1;
            }
            else
            {
                selectedWeapon--;
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha1))
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
            foreach (Transform weapon in transform)
            {
                if (i == selectedWeapon)
                {
                    //weapon.gameObject.SetActive(true);
                    weapon.GetComponent<WeaponBehavior>().SetSprite(true);
                }
                else
                {
                    weapon.GetComponent<WeaponBehavior>().SetSprite(false);
                }
                i++;
            }
        }
    }

    public void AddWeapon(GameObject weapon)
    {
        //GO weapon becomes child of the weapons object
        // Sets "newParent" as the new parent of the child GameObject.
        weapon.transform.SetParent(transform);
    }
}

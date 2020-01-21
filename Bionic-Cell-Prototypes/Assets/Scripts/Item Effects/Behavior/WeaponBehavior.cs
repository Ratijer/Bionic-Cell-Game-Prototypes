using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehavior : MonoBehaviour
{
    public WeaponSOAsset weaponSOAsset;
    private float speed;
    private Vector3 direction;
    private PortBehavior port;

    public delegate void VoidWithNoArguments();
    public event VoidWithNoArguments AttackEvent;

    //public WeaponBehavior(PortBehavior portBehav)
    //{
    //    port = portBehav;
    //}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Attach to port
        transform.position = port.transform.position;   //Follow port position
        transform.rotation = port.transform.rotation;   //Follow port rotation
        //transform.position += transform.up * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))    //Do attack
        {
            DoEffect();
        }
    }

    public void SetPort(PortBehavior portBehav)
    {
        port = portBehav;
    }

    public void SetSOAsset(ItemBehavior item)
    {
        weaponSOAsset = item.weaponSOAsset;
        //First weapon equipped will automatically be selected
        if(WeaponSelection.instance.GetComponent<Transform>().childCount == 0)
            gameObject.GetComponent<SpriteRenderer>().sprite = weaponSOAsset.weaponSpriteSelected;
        else
            gameObject.GetComponent<SpriteRenderer>().sprite = weaponSOAsset.weaponSprite;
    }

    public void SetSpriteSelected(bool selected)    //bool selected detetermines if the "selected" sprite is used
    {
        if(selected)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = weaponSOAsset.weaponSpriteSelected;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = weaponSOAsset.weaponSprite;
        }
    }

    private void DoEffect()
    {
        if (gameObject.GetComponent<SpriteRenderer>().sprite == weaponSOAsset.weaponSpriteSelected)
        {
            if (AttackEvent != null)
            {
                AttackEvent.Invoke();
            }
        }
     }

    //public void SetDetails(float speed, Vector3 direction)
    //{
    //    this.speed = speed;
    //    transform.up = direction;
    //}
}




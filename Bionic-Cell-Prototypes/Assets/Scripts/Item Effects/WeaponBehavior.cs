using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehavior : MonoBehaviour
{
    public WeaponSOAsset weaponSOAsset;
    private float speed;
    private Vector3 direction;
    private PortBehavior port;

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
    }

    public void SetPort(PortBehavior portBehav)
    {
        port = portBehav;
    }

    public void SetSOAsset(ItemBehavior item)
    {
        weaponSOAsset = item.weaponSOAsset;
        gameObject.GetComponent<SpriteRenderer>().sprite = weaponSOAsset.weaponSprite;
    }

    //public void SetDetails(float speed, Vector3 direction)
    //{
    //    this.speed = speed;
    //    transform.up = direction;
    //}
}

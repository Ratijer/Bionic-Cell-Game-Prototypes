using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    public WeaponSOAsset weaponSOAsset;
    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.GetComponent<SpriteRenderer>().sprite = weaponSOAsset.weaponSprite;
        gameObject.transform.parent.GetComponent<SpriteRenderer>().sprite = weaponSOAsset.weaponSprite;     //Change item sprite
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)     //Equip on collision
    {
        if (collision.tag == "Port")
        {
            collision.gameObject.GetComponent<PortBehavior>().EquipItem(this);
            Destroy(transform.parent.gameObject);   //Remove item from scene
        }
    }
}

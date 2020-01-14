using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public ProjectileSOAsset projectileSOAsset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSOAsset(WeaponBehavior weapon)
    {
        projectileSOAsset = weapon.weaponSOAsset.projectileSOAsset;
        gameObject.GetComponent<SpriteRenderer>().sprite = projectileSOAsset.projectileSprite;
    }
}

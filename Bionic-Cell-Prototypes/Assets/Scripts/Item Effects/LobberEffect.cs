using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobberEffect : WeaponEffect
{
    private GameObject weapon;
    private WeaponBehavior weaponBehavior;

    private float cooldownLeft; //Is at zero unless key is pressed
    private float cooldown;  //Cool down in seconds
    private bool isCooldown; //Determines if projectiles are on cooldown

    public LobberEffect(PortBehavior port, ItemBehavior item) : base(port, item) { }

    public override void RegisterEventEffect()
    {
        //Equip weapon
        weapon = GameObject.Instantiate(item.weaponSOAsset.weaponPrefab, port.transform.position /*+ new Vector3(0, 0.5f, 0)*/, Quaternion.identity) as GameObject;
        weaponBehavior = weapon.GetComponent<WeaponBehavior>();
        weaponBehavior.SetSOAsset(item);
        weaponBehavior.SetPort(port);

        //port.AttackEvent += CauseEventEffect;
        weaponBehavior.AttackEvent += CauseEventEffect;

        //Cooldown is fire rate
        cooldown = weaponBehavior.weaponSOAsset.projectileSOAsset.fireRate;     

        //Add to weapons game object in hierarchy 
        WeaponSelection.instance.AddWeapon(weapon);

        Debug.Log("Registered Lobber!");
    }

    public override void CauseEventEffect()
    {
        //Shooting effect
        if (isCooldown == false)
        {
            Debug.Log("Lobber activated!");
            Shoot();
            //Cooldown process begin
            isCooldown = true;  
            cooldownLeft = cooldown;   
        }
        if (isCooldown)
        {
            cooldownLeft -= 1 / cooldown * Time.deltaTime;      //Cooldown process (goes from 1 (or higher) to 0)

            //Cooldown resets when current cooldown is finished.
            if (cooldownLeft <= 0)
            {
                isCooldown = false;
                cooldownLeft = cooldown;
            }
        }
    }

    private void Shoot()
    {
        //Shoot projectile
        //Create projectile
        GameObject projectile = GameObject.Instantiate(weaponBehavior.weaponSOAsset.projectileSOAsset.projectilePrefab, weapon.transform.position, weapon.transform.rotation);
        projectile.GetComponent<ProjectileBehavior>().SetSOAsset(weaponBehavior);       //Give the projectile a sprite from the projectileSOAsset
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        //Make it fly
        rb.AddForce(weapon.transform.up * weaponBehavior.weaponSOAsset.projectileSOAsset.speed, ForceMode2D.Impulse);

        //Destroy projectile
        GameObject.Destroy(projectile, weaponBehavior.weaponSOAsset.projectileSOAsset.lifeTime);
    }
}

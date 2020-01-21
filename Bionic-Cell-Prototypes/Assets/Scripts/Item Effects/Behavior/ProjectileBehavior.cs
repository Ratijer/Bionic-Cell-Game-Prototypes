using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public ProjectileSOAsset projectileSOAsset;
    private float damage;

    // Start is called before the first frame update
    void Start()
    {
        damage = projectileSOAsset.damage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSOAsset(WeaponBehavior weaponBehavior)
    {
        projectileSOAsset = weaponBehavior.weaponSOAsset.projectileSOAsset;
        gameObject.GetComponent<SpriteRenderer>().sprite = projectileSOAsset.projectileSprite;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //For testing only
        if (collider.tag == "Enemy")
        {
            collider.GetComponent<EnemyBehavior>().TakeDamage(damage);
            //For testing only
            Destroy(gameObject);
        }
    }
}

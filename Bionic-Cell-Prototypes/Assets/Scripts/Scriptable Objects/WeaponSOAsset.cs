using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/WeaponSOAsset", order = 1)]
public class WeaponSOAsset : ScriptableObject
{
    // Anything specific to ONE weapon
    [Header("Weapon Visual")]
    public GameObject weaponPrefab;
    public Sprite weaponSprite;

    [Header("Weapon Effect")]
    public string weaponScriptName;
    public ProjectileSOAsset projectileSOAsset;

    [Header("Stats")]
    public WeaponType weaponType;
    public int damage;      //Does not apply to projectiles and weapons that shoot projectiles
    public int health;      //Item health 
    public int buffNum;     //Increases things like speed and damage. For debuff, use -buffNum.
    public string description;

    public enum WeaponType
    {
        Melee,
        Ranged,
        Projectile,
        Defensive,
        Buff
    }
}

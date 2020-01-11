using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ItemSOAsset", order = 1)]
public class ItemSOAsset : ScriptableObject
{
    // Anything specific to ONE weapon

    [Header("Item Form")]
    public GameObject itemPrefab;
    public Sprite itemSprite;

    [Header("Weapon Form")]
    public GameObject usableItemPrefab;
    public Sprite usableItemSprite;
    public Sprite selectedItemSprite;
    public string description;
    public int damage;
    public int health;

    [Header("Item Type")]
    public ItemType itemType;
    public ItemState itemState;

    [Header("Item Effect")]
    public string itemScriptName;
    public ProjectileSOAsset projectileSOAsset;

    [Header("Buff Stats")]      //For debuffs, use a negative number 
    public int buffNum;
}

public enum ItemType
{
    Melee,
    Ranged,
    Projectile,
    //Propulsion,
    Defensive,
    Buff
}

public enum ItemState
{
    Active,
    Passive
}
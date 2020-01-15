using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ProjectileSOAsset", order = 1)]
public class ProjectileSOAsset : ScriptableObject
{
    public float speed;     //How fast the projectile moves
    public float damage;
    public float fireRate;  //How how often it can be fired 
    public GameObject projectilePrefab;
    public Sprite projectileSprite;
}

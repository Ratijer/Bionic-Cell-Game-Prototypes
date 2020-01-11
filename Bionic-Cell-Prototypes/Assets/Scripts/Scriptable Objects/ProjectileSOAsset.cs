using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ProjectileSOAsset", order = 1)]
public class ProjectileSOAsset : ScriptableObject
{
    public float speed;
    public int damage;
    public float fireRate;
    public GameObject projectilePrefab;
    public Sprite projectileSprite;
}

using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ProjectileSOAsset", order = 1)]
public class ProjectileSOAsset : ScriptableObject
{
    public int speed;
    public int damage;
    public GameObject projectilePrefab;
    public Sprite projectileSprite;
}

using UnityEngine;

// Skrip untuk bikin prefab weapon
[CreateAssetMenu(fileName = "NewWeapon", menuName = "Weapons/Weapon")]
public class Weapon : ScriptableObject
{
    public string weaponName;
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    public float damage = 25f;
    public float shootForce = 10f;
    public float range = 5f;
}

using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public PlayerShoot playerShoot;
    public Weapon[] weapons; // Array of available weapons
    private int currentWeaponIndex = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) // Press Q to switch weapons
        {
            currentWeaponIndex = (currentWeaponIndex + 1) % weapons.Length;
            if (playerShoot != null)
            {
                playerShoot.ChangeWeapon(weapons[currentWeaponIndex]);
            }
        }
    }
}

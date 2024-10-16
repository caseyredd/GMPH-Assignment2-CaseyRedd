using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    [SerializeField] List<GameObject> Weapons;
    [SerializeField] int weaponNum;
    [SerializeField] GameObject spawnLocation;
    /// <summary>
    /// The direction of the initial velocity of the fired projectile. That is,
    /// this is the direction the gun is aiming in.
    /// </summary>
    public Vector3 FireDirection
    {
        get
        {
            return SpawnPosition-transform.position;
        }
    }

    /// <summary>
    /// The position in world space where a projectile will be spawned when
    /// Fire() is called.
    /// </summary>
    public Vector3 SpawnPosition
    {
        get
        {
            return spawnLocation.transform.position;
        }
    }

    /// <summary>
    /// The currently selected weapon object, an instance of which will be
    /// created when Fire() is called.
    /// </summary>
    public GameObject CurrentWeapon
    {
        get
        {
            return Weapons[weaponNum];
        }
    }

    /// <summary>
    /// Spawns the currently active projectile, firing it in the direction of
    /// FireDirection.
    /// </summary>
    /// <returns>The newly created GameObject.</returns>
    public GameObject Fire()
    {
        GameObject particle = Instantiate(CurrentWeapon, new Vector3(SpawnPosition.x, SpawnPosition.y, 0), Quaternion.identity);
        return particle;
    }

    /// <summary>
    /// Moves to the next weapon. If the last weapon is selected, calling this
    /// again will roll over to the first weapon again. For example, if there
    /// are 4 weapons, calling this 4 times will end up with the same weapon
    /// selected as if it was called 0 times.
    /// </summary>
    public void CycleNextWeapon()
    {
        weaponNum++;
        if (weaponNum >= 4)
        {
            weaponNum = 0;
        }
    }

    void Update()
    {
        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            CycleNextWeapon();
        }
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            transform.Rotate(new Vector3(0, 0, transform.rotation.z + 1));
        }
        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            transform.Rotate(new Vector3(0, 0, transform.rotation.z - 1));
        }
        if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            GameObject particle = Fire();
            particle.GetComponent<Particle2D>().velocity = new Vector3(FireDirection.x, FireDirection.y, 0);
        }
    }
}

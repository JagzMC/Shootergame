using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public enum WeaponEquipped
    {
        shotgun,
        ar,
        burstfire,
        rocket,
        machinegun
    }
    
    [field: SerializeField] public WeaponEquipped weapon { get; private set; }
    
    [Header ("Weapons")]
    [SerializeField] private WeaponBase Weapon1;
    [SerializeField] private WeaponBase Weapon2;
    [SerializeField] private WeaponBase Weapon3;
    [SerializeField] private WeaponBase Weapon4;
    [SerializeField] private WeaponBase Weapon5;
    private bool weaponShootToggle;

    [Header ("Player UI")]
    [SerializeField] private TextMeshProUGUI ammo;
    [SerializeField] private TextMeshProUGUI currentWeapon;

    private int currentGun;
    
    private void Start()
    {
        InputManager.Init(this);
        InputManager.EnableInGame();
        if (weapon == WeaponEquipped.shotgun) currentGun = 1;
        if (weapon == WeaponEquipped.ar) currentGun = 2;
        if (weapon == WeaponEquipped.burstfire) currentGun = 3;
        if (weapon == WeaponEquipped.rocket) currentGun = 4;
        if (weapon == WeaponEquipped.machinegun) currentGun = 5;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentGun <= 4) currentGun++;
            else currentGun = 1;
        }

        if (currentGun == 1)
        {
            ammo.text = Weapon1.GetAmmo().ToString();
            currentWeapon.text = Weapon1.name;
        }
        if (currentGun == 2)
        {
            ammo.text = Weapon2.GetAmmo().ToString();
            currentWeapon.text = Weapon2.name;
        }
        if (currentGun == 3)
        {
            ammo.text = Weapon3.GetAmmo().ToString();
            currentWeapon.text = Weapon3.name;
        }
        if (currentGun == 4)
        {
            ammo.text = Weapon4.GetAmmo().ToString();
            currentWeapon.text = Weapon4.name;
        }
        if (currentGun == 5)
        {
            Weapon5.StartShooting();
            Weapon5.StopShooting();
            ammo.text = Weapon5.GetAmmo().ToString();
            currentWeapon.text = Weapon5.name;
        }
        
    }

    public void Shoot()
    {
        if (currentGun == 1)
        {
            print("I shot: " + InputManager.GetCameraRay());
            weaponShootToggle = !weaponShootToggle;
            if (weaponShootToggle) Weapon1.StartShooting();
            else Weapon1.StopShooting();
        }

        else if (currentGun == 2)
        {
            print("I shot: " + InputManager.GetCameraRay());
            weaponShootToggle = !weaponShootToggle;
            if (weaponShootToggle) Weapon2.StartShooting();
            else Weapon2.StopShooting();
        }
        else if (currentGun == 3)
        {
            print("I shot: " + InputManager.GetCameraRay());
            weaponShootToggle = !weaponShootToggle;
            if (weaponShootToggle) Weapon3.StartShooting();
            else Weapon3.StopShooting();
        }
        else if (currentGun == 4)
        {
            print("I shot: " + InputManager.GetCameraRay());
            weaponShootToggle = !weaponShootToggle;
            if (weaponShootToggle) Weapon4.StartShooting();
            else Weapon4.StopShooting();
        }
        else if (currentGun == 5)
        {
            print("I shot: " + InputManager.GetCameraRay());
            weaponShootToggle = !weaponShootToggle;
            if (weaponShootToggle) Weapon5.StartShooting();
            else Weapon5.StopShooting();
        }
        
        
    }

    public void Reload()
    {
        Weapon1.ReloadGun();
        Weapon2.ReloadGun();
        Weapon3.ReloadGun();
        Weapon4.ReloadGun();
        Weapon5.ReloadGun();
    }
}

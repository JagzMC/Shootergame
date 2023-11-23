using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR : WeaponBase
{
    
    [SerializeField] private Rigidbody myBullet;
    [SerializeField] private Rigidbody myBullet2;
    [SerializeField] private float force = 75;
    [SerializeField] private int ammo = 25;
    private int maxAmmo;

    private void Start()
    {
        maxAmmo = ammo;
    }
    
    protected override void Attack(float percent)
    {
        if (ammo > 0)
        {
            print("My weapon attacked" + percent);
            Ray camRay = InputManager.GetCameraRay();
            Rigidbody rb = Instantiate(percent > 0.5f ? myBullet2 : myBullet, camRay.origin + new Vector3(0, 0, 0),
                transform.rotation);
            rb.AddForce(Mathf.Max(percent, 0.2f) * force * camRay.direction, ForceMode.Impulse);
            ammo--;
        }
    }

    public override int GetAmmo()
    {
        return ammo;
    }

    public void SetAmmo(int ammo)
    {
        this.ammo = ammo;
    }

    public override void ReloadGun()
    {
        ammo = maxAmmo;
    }
    
}

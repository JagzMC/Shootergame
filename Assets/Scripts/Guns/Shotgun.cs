using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : WeaponBase
{

    [SerializeField] private Rigidbody myBullet;
    [SerializeField] private Rigidbody myBullet2;
    [SerializeField] private float force = 50;
    [SerializeField] private int ammo = 5;
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
            Rigidbody rb = Instantiate(percent > 0.5f ? myBullet2 : myBullet, camRay.origin + new Vector3(0, .05f, 0),
                transform.rotation);
            rb.AddForce(Mathf.Max(percent, 0.2f) * force * camRay.direction, ForceMode.Impulse);
            Rigidbody rb2 = Instantiate(percent > 0.5f ? myBullet2 : myBullet,
                camRay.origin + new Vector3(.05f, .05f, 0), transform.rotation);
            rb2.AddForce(Mathf.Max(percent, 0.2f) * force * camRay.direction, ForceMode.Impulse);
            Rigidbody rb3 = Instantiate(percent > 0.5f ? myBullet2 : myBullet,
                camRay.origin + new Vector3(-.05f, .05f, 0), transform.rotation);
            rb3.AddForce(Mathf.Max(percent, 0.2f) * force * camRay.direction, ForceMode.Impulse);
            Rigidbody rb4 = Instantiate(percent > 0.5f ? myBullet2 : myBullet, camRay.origin + new Vector3(0, 0, 0),
                transform.rotation);
            rb4.AddForce(Mathf.Max(percent, 0.2f) * force * camRay.direction, ForceMode.Impulse);
            Rigidbody rb5 = Instantiate(percent > 0.5f ? myBullet2 : myBullet, camRay.origin + new Vector3(.05f, 0, 0),
                transform.rotation);
            rb5.AddForce(Mathf.Max(percent, 0.2f) * force * camRay.direction, ForceMode.Impulse);
            Rigidbody rb6 = Instantiate(percent > 0.5f ? myBullet2 : myBullet, camRay.origin + new Vector3(-.05f, 0, 0),
                transform.rotation);
            rb6.AddForce(Mathf.Max(percent, 0.2f) * force * camRay.direction, ForceMode.Impulse);
            Rigidbody rb7 = Instantiate(percent > 0.5f ? myBullet2 : myBullet, camRay.origin + new Vector3(0, -.05f, 0),
                transform.rotation);
            rb7.AddForce(Mathf.Max(percent, 0.2f) * force * camRay.direction, ForceMode.Impulse);
            Rigidbody rb8 = Instantiate(percent > 0.5f ? myBullet2 : myBullet,
                camRay.origin + new Vector3(.05f, -.05f, 0), transform.rotation);
            rb8.AddForce(Mathf.Max(percent, 0.2f) * force * camRay.direction, ForceMode.Impulse);
            Rigidbody rb9 = Instantiate(percent > 0.5f ? myBullet2 : myBullet,
                camRay.origin + new Vector3(-.05f, -.05f, 0), transform.rotation);
            rb9.AddForce(Mathf.Max(percent, 0.2f) * force * camRay.direction, ForceMode.Impulse);
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

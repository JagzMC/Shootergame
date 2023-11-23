using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BurstFire : WeaponBase
{
    
    [SerializeField] private Rigidbody myBullet;
    [SerializeField] private Rigidbody myBullet2;
    [SerializeField] private float force = 75;
    [SerializeField] private int ammo = 30;
    private int maxAmmo;
    private int timer = 500;
    private int shot = 3;
    private float percent;

    private void Start()
    {
        maxAmmo = ammo;
    }

    private void Update()
    {
        timer++;
        Debug.Log(timer);
        ExtraFire();
    }
    
    protected override void Attack(float percent)
    {
        if (ammo > 0)
        {
            this.percent = percent;
            if (shot == 3) TimerReset();
            print("My weapon attacked" + percent);
            Ray camRay = InputManager.GetCameraRay();
            Rigidbody rb = Instantiate(percent > 0.5f ? myBullet2 : myBullet, camRay.origin + new Vector3(0, 0, 0), transform.rotation);
            rb.AddForce(Mathf.Max(percent, 0.2f) * force * camRay.direction, ForceMode.Impulse);
            ammo--;
            shot++;
        }
    }

    private void TimerReset()
    {
        timer = 0;
        shot = 0;
    }

    private void ExtraFire()
    {
        if (timer == 25) Attack(percent);
        if (timer == 50) Attack(percent);
        
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

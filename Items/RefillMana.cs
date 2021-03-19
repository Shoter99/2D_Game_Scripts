using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefillMana : MonoBehaviour
{

   private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);

        Guns.Handgun.currentAmmo += Random.Range(1,10);
        if (Guns.Handgun.currentAmmo > Guns.Handgun.maxAmmo) Guns.Handgun.currentAmmo = Guns.Handgun.maxAmmo;
        Guns.Shotgun.currentAmmo += Random.Range(2, 5);
        if (Guns.Shotgun.currentAmmo > Guns.Shotgun.maxAmmo) Guns.Shotgun.currentAmmo = Guns.Shotgun.maxAmmo;
        
    }
}

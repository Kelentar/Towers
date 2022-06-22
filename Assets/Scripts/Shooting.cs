using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    [Header("Снаряд по центру")]
    public bool useBullets = false;

    [Header("Ресурси")]
    public GameObject bulletPrefab;

    
    public Transform firePoint;

    public Target snipe;

    [Header("Змінні")]
    public float fireRate = 1f;
    public float fireCountdown = 0f;

    
    public void Shoot()
    {
        if (useBullets == true)
        {
            
            GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Bullet bullet = bulletGO.GetComponent<Bullet>();
            
            if (bullet != null)
            {
                
                bullet.Seek(snipe.target);
                
            }
                

        }
    }
   
}

// Офк, поки що непотрібний скрипт

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_1 : MonoBehaviour
{
    [Header("Use Bullets (default)")]
    public bool useBullets_1 = false;

    public GameObject bulletPrefab;
    public float fireRate = 1f;
    public float fireCountdown = 0f;

    public Transform firePoint;
    public Target snipe;

    public void Shoot1()
    {
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet_1 bullet = bulletGO.GetComponent<Bullet_1>();

        if (bullet != null)
            bullet.Seek(snipe.target);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [Header("Снаряд справа")]
    public bool useBullets_1_1 = false;
    [Header("Снаряд зліва")]
    public bool useBullets_1_2 = false;
    [Header("Снаряд по центру")]
    public bool useBullets_1_3 = false;
    [Header("Неактивний скрипт - дороблюється")]
    public bool useBullets_2 = false;
    [Header("Варіант з колайдерами")]
    public bool useBullets_3 = false;

    [Header("Ресурси")]
    public GameObject bulletPrefab_1;
    public GameObject bulletPrefab_2;
    public GameObject bulletPrefab_3;

    public Transform firePoint_1; // Поінт для правої частини квадрата
    public Transform firePoint_2; // Поінт для лівої частини квадрата
    public Transform firePoint_3; // Поінт для центру
    public Target snipe; // Наведення


    [Header("Змінні")]
    public float fireRate = 1f;
    public float fireCountdown = 0f;

    public void Shoot1_1()
    {
        if (useBullets_1_1 == true)
        {
            GameObject bulletGO_1_1 = Instantiate(bulletPrefab_1, firePoint_1.position, firePoint_1.rotation);
            Bullet_1 bullet = bulletGO_1_1.GetComponent<Bullet_1>();

            if (bullet != null)
                bullet.Seek(snipe.target);

        }
    }
    public void Shoot1_2()
    {
        if (useBullets_1_2 == true)
        {
            GameObject bulletGO_1_2 = Instantiate(bulletPrefab_2, firePoint_2.position, firePoint_2.rotation);
            Bullet_1 bullet = bulletGO_1_2.GetComponent<Bullet_1>();

            if (bullet != null)
                bullet.Seek(snipe.target);

        }
    }
    public void Shoot1_3()
    {
        if (useBullets_1_3 == true)
        {
            GameObject bulletGO_1_3 = Instantiate(bulletPrefab_3, firePoint_3.position, firePoint_3.rotation);
            Bullet_1 bullet = bulletGO_1_3.GetComponent<Bullet_1>();

            if (bullet != null)
                bullet.Seek(snipe.target);

        }
    }
    public void Shoot2()
    {
        if (useBullets_2 == true)
        {
            GameObject bulletGO_2 = Instantiate(bulletPrefab_2, firePoint_3.position, firePoint_3.rotation);
            Bullet_2 bullet = bulletGO_2.GetComponent<Bullet_2>();

            if (bullet != null)
                bullet.Seek(snipe.target);
        }
    }
    public void Shoot3()
    {
        if (useBullets_3 == true)
        {
            GameObject bulletGO_3 = Instantiate(bulletPrefab_3, firePoint_3.position, firePoint_3.rotation);
            Bullet_3 bullet = bulletGO_3.GetComponent<Bullet_3>();

            if (bullet != null)
                bullet.Seek(snipe.target);
        }
    }
}

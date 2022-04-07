// Скрипт турелі, для активації і навправлення снарядів

using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour
{

    #region private
    private float range = 15f;
    private Target snipe;
    #endregion

    #region public
    public Shooting shooting;
    public Lasers lasers;
    #endregion

    // Поки що непотрібний хлам для повороту башні турелі
    //[Header("Unity Setup Fields")]

    //public Transform partToRotate;
    //public float turnSpeed = 10f;

    //public Transform firePoint;  

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        snipe = GetComponent<Target>();
        snipe.UpdateTarget();
    }

    void Update()
    {
        
        if (snipe.target == null)
        {
            if (lasers.useLaser)
            {
                if (lasers.lineRenderer.enabled)
                {
                    lasers.lineRenderer.enabled = false;
                    //impactEffect.Stop();
                    //impactLight.enabled = false;
                }
            }

            return;
        } // Захват лазером

        if (lasers.useLaser)
        {
            lasers.Laser();
        } // Включений лазер
        if (shooting.useBullets_1_1)
        {
            if (shooting.fireCountdown <= 0f)
            {
                shooting.Shoot1_1();
                shooting.fireCountdown = 1f / shooting.fireRate;
            }

            shooting.fireCountdown -= Time.deltaTime;
        } // Включена пуля в слоті 1 поінт справа
        if (shooting.useBullets_1_2)
        {
            if (shooting.fireCountdown <= 0f)
            {
                shooting.Shoot1_2();
                shooting.fireCountdown = 1f / shooting.fireRate;
            }

            shooting.fireCountdown -= Time.deltaTime;
        } // Включена пуля в слоті 1 поінт зліва
        if (shooting.useBullets_1_3)
        {
            if (shooting.fireCountdown <= 0f)
            {
                shooting.Shoot1_3();
                shooting.fireCountdown = 1f / shooting.fireRate;
            }

            shooting.fireCountdown -= Time.deltaTime;
        } // Включена пуля в слоті 1 поінт по центру
        if (shooting.useBullets_2)
        {
            if (shooting.fireCountdown <= 0f)
            {
                shooting.Shoot2();
                shooting.fireCountdown = 1f / shooting.fireRate;
            }

            shooting.fireCountdown -= Time.deltaTime;
        } // Включена пуля в слоті 2
        if (shooting.useBullets_3)
        {
            if (shooting.fireCountdown <= 0f)
            {
                shooting.Shoot3();
                shooting.fireCountdown = 1f / shooting.fireRate;
            }

            shooting.fireCountdown -= Time.deltaTime;
        } // Включена пуля в слоті 3
    }

    // Захват для повороту башні
    //void LockOnTarget()
    //{
    //    Vector3 dir = target.position - transform.position;
    //    Quaternion lookRotation = Quaternion.LookRotation(dir);
    //    Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
    //    partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    //} 


    // Візуалізація радіуса таргет зони

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
// Скрипт турелі, для активації і навправлення снарядів

using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour
{
    //[SerializeField]
    //private Transform target;
   

    #region private

    private Target snipe;
    #endregion

    #region public
    public int GizmozRangeX;
    public int GizmozRangeY;

    public Shooting shooting;
    public Lasers lasers;
    #endregion

    
   //[Header("Unity Setup Fields")]

   // public Transform partToRotate;
   // public float turnSpeed = 10f;

   // public Transform firePoint;

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
                }
            }

            return;
        } // Захват лазером

        if (lasers.useLaser)
        {
            lasers.Laser();
        } // Включений лазер
        if (shooting.useBullets)
        {
            if (shooting.fireCountdown <= 0f)
            {
                shooting.Shoot();
                shooting.fireCountdown = 1f / shooting.fireRate;
            }

            shooting.fireCountdown -= Time.deltaTime;
        } 
        
    }
    


    // Візуалізація радіуса таргет зони

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(GizmozRangeX, GizmozRangeY));
    }
}
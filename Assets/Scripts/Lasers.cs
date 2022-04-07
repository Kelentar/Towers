// Скрипт на лазер

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasers : MonoBehaviour
{
    #region public
    [Header("Use Laser")]
    public bool useLaser = false;

    public int damageOverTime = 30;
    public float slowAmount = .5f;

    public LineRenderer lineRenderer;
    public Target snipe;
    public Transform firePoint;
    #endregion
    public void Laser()
    {
        snipe.targetEnemy.TakeDamage(damageOverTime * Time.deltaTime); // Урон
        //snipe.targetEnemy.Slow(slowAmount); 

        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            //impactEffect.Play();
            //impactLight.enabled = true;
        }

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, snipe.target.position);

        Vector3 dir = firePoint.position - snipe.target.position;

        //impactEffect.transform.position = target.position + dir.normalized;
        //impactEffect.transform.rotation = Quaternion.LookRotation(dir);
    }
}

// Звичайний снаряд і снаряд з радіусом

using UnityEngine;

public class Bullet_1 : MonoBehaviour
{

    private Transform target;

    #region public
    public float speed = 70f;
    public float explosionRadius = 0f;

    public int damage;

    public GameObject impactEffect;
    #endregion

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {

        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);

    } // Зміна таргету, якщо попередній вмирає. Реєстрація DPS. Пересування снаряду до ворога

    void HitTarget()
    {
        //GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        //Destroy(effectIns, 5f);

        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        Destroy(gameObject);
    } // Перевірка радіусу, якщо його немає - звичайний снаряд

    void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (Collider2D collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    } // Радіус підриву

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }
        Destroy(gameObject);
    } // Сама механіка нанесення ушкоджень

    // Реєстрація DPSa через колайдери
    //private void OnTriggerEnter2D(Collider2D hitInfo)
    //{
    //    Enemy enemy = hitInfo.GetComponent<Enemy>();
    //    if (enemy != null)
    //    {
    //        enemy.TakeDamage(damage);
    //    }
    //    Destroy(gameObject);
    //} 

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
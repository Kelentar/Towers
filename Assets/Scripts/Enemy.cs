// Рух і хп ворога

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    #region private
    private bool isDead = false;
    [SerializeField]
    private float currentHealth;

    

    Transform enemy;
    public float navigationTime = 0;
    #endregion

    //------------------------------

    #region public
    public float slowAmount = .5f;

    public float startSpeed = 0f;
    public int target = 0;
    public Transform exit;
    public Transform[] wayPoints;
    public float navigation;

    [HideInInspector]
    //public float speed;

    public float startHealth = 100;

    public Camera cam;

    //public int worth = 50;

    public GameObject deathEffect;

    public Image healthBar;
    #endregion

    void Start()
    {
        cam = Camera.main;
        enemy = GetComponent<Transform>();

        //--------------------------

        //speed = startSpeed;
        currentHealth = startHealth;
    } // Компоненти, хп
   

    void Update()
    {
        if(wayPoints != null)
        {
            
            navigationTime += Time.deltaTime * .8f;
              
            
            
            if (navigationTime > navigation)
            {
                if(target < wayPoints.Length)
                {
                    enemy.position = Vector2.MoveTowards(enemy.position, wayPoints[target].position, navigationTime);
                }else
                {
                    enemy.position = Vector2.MoveTowards(enemy.position, exit.position, navigationTime);
                }
                navigationTime = 0;
            }
        }
    } // Пересування

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "waypoint")
        {
            target += 1;
        }
        else if (collision.tag == "final")
        {
            Manager.Instance.removeEnemyFromScreen();
            cam.transform.position = Vector2.right * 100;
            
            
        }
    } // І це теж

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0 && !isDead)
        {

            Die();
        }

    }
    //public void Slow(float pct)
    //{
    //    //speed = startSpeed * (1f - pct);
    //    navigationTime = navigationTime * 2 / 3;
    //}

    void Die()
    {
        isDead = true;

        //GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 5f);

        Destroy(gameObject);
    }

}
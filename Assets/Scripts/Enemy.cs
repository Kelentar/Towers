// Рух і хп ворога

using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class Enemy : MonoBehaviour
{
    #region private
    private bool isDead = false;
    [SerializeField]
    private float currentHealth;



    Transform enemy;


    #endregion

    //------------------------------

    #region public
    public int ID = 0;
    public float navigationTime = 0;
    public bool isFlipped = true;

    public float slowAmount = .5f;

    public float startSpeed;
    public int target = 0;
    public Transform exit;
    public Transform[] wayPoints;
    public float navigation;
    public int time;
    

    public Transform[] drop;

    [SerializeField]
    private GameObject[] items;


    public int dropIndex;
    public int maxRange;
    

    public float startHealth = 100;

    public Camera cam;
    public UserInterface user;


    public GameObject deathEffect;

    public Image healthBar;
    #endregion

    void Start()
    {
        cam = Camera.main;
        enemy = GetComponent<Transform>();
        ID = user.ID;


        

        
        
        currentHealth = startHealth;
    } // Компоненти, хп


    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "waypoint")
        {
            StartCoroutine(Movement());

            target += 1;
            
        }
        else if (collision.tag == "final")
        {
            
            GetComponent<Manager>().removeEnemyFromScreen();
            //cam.transform.position = Vector2.right * 100;


        }
    }


    IEnumerator Movement()
    {
        yield return new WaitForSeconds(time);
        if (wayPoints != null)
        {

            if (target < wayPoints.Length)
            {

                enemy.position = wayPoints[target].position;
                if (wayPoints[target - 1].position.x > wayPoints[target].position.x && isFlipped)
                {
                    enemy.Rotate(0f, 180f, 0f);
                    isFlipped = false;
                }

                else if (wayPoints[target - 1].position.x < wayPoints[target].position.x && !isFlipped)
                {
                    enemy.Rotate(0f, 180f, 0f);
                    isFlipped = true;
                }
            }
            
        }
            else
            {
                enemy.position = exit.position;
                transform.rotation = exit.rotation;
                
            }
        }


    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0 && !isDead)
        {
            
            //var spawnPosition = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), -2);
            //enemy.position = spawnPosition;
            Die();
            
        }

    }

    void Die()
    {
        isDead = true;

        //dropIndex++;
        //if(dropIndex > Count) dropIndex = 0;
        int gen = Random.Range(0, maxRange);
        Instantiate(items[gen], drop[dropIndex].position, Quaternion.identity);
        Destroy(gameObject);
        if (items[gen].GetComponentInChildren<Tower>().enabled == true)
        {
            items[gen].GetComponentInChildren<Tower>().enabled = false;
        }

        
        
        
        //GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 5f);


    }
    

 


}
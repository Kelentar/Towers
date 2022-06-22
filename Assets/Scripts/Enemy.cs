using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Enemy : MonoBehaviour
{
    #region private
    Transform enemy;
    private bool isDead = false;
    [SerializeField]
    private float currentHealth;
    [SerializeField]
    private GameObject[] items;
    #endregion


    #region public
    public float startHealth = 100;
    public float navigationTime = 0;
    public bool isFlipped = true;
    public float slowAmount = .5f;
    public float startSpeed;
    public int target = 0;
    public Transform exit;
    public Transform[] wayPoints;
    public Transform[] drop;
    public Camera cam;
    public UserInterface user;
    public GameObject deathEffect;
    public Image healthBar;
    public float navigation;
    public int time;
    public int dropIndex;
    public int maxRange;
    #endregion

    void Start()
    {
        cam = Camera.main;
        enemy = GetComponent<Transform>();
        
        currentHealth = startHealth;
    } 

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
            Die();
            
        }

    }

    void Die()
    {
        isDead = true;
        int gen = Random.Range(0, maxRange);
        Instantiate(items[gen], drop[dropIndex].position, Quaternion.identity);
        Destroy(gameObject);
        if (items[gen].GetComponentInChildren<Tower>().enabled == true)
        {
            items[gen].GetComponentInChildren<Tower>().enabled = false;
        }
    }
}
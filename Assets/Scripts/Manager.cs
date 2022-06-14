using System.Collections;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject enemies;
    public int maxEnemiesOnScreen;
    public int totalEnemies;
    public int enemiesPerSpawn;
    //public UserInterface user;

    public float timeBetweenWaves = 10f;
    public float countdown = 10f;

    [SerializeField]
    int enemiesOnScreen = 1110;

    public float spawnDelay = 10f;

   

   



    private void Update()
    {
       
        //if (gameObject.tag == "BuildingSideFull")
        //{
            if (countdown <= 0f)
            {   
                StartCoroutine(SpawnWave());
                countdown = timeBetweenWaves;
                return;
            }
            countdown -= Time.deltaTime;
            countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

       // }
        
    }


    IEnumerator SpawnWave()
    {


        SpawnEnemy();
        
            
        yield return new WaitForSeconds(spawnDelay); 
        

            
        
    }
     
    void SpawnEnemy()
    {
        GameObject newEnemy = Instantiate(enemies) as GameObject;
        newEnemy.transform.position = spawnPoint.transform.position;
 
        
        

    }

    public void removeEnemyFromScreen()
    {
        if(enemiesOnScreen > 0)
        {
            enemiesOnScreen -= 1;
        }
    }
}


//using UnityEngine;

//public class Manager : MonoBehaviour
//{

//    public static BuildManager instance;

//    void Awake()
//    {
//        if (instance != null)
//        {
//            Debug.LogError("More than one BuildManager in scene!");
//            return;
//        }
//        instance = this;
//    }

//    public GameObject buildEffect;
//    public GameObject sellEffect;

//    private TurretBlueprint turretToBuild;
//    private Node selectedNode;

//    public NodeUI nodeUI;

//    public bool CanBuild { get { return turretToBuild != null; } }
//    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

//    public void SelectNode(Node node)
//    {
//        if (selectedNode == node)
//        {
//            DeselectNode();
//            return;
//        }

//        selectedNode = node;
//        turretToBuild = null;

//        nodeUI.SetTarget(node);
//    }

//    public void DeselectNode()
//    {
//        selectedNode = null;
//        nodeUI.Hide();
//    }

//    public void SelectTurretToBuild(TurretBlueprint turret)
//    {
//        turretToBuild = turret;
//        DeselectNode();
//    }

//    public TurretBlueprint GetTurretToBuild()
//    {
//        return turretToBuild;
//    }

//}

using System.Collections;
using UnityEngine;

public class Manager : Loader<Manager>
{
    public GameObject spawnPoint;
    public GameObject[] enemies;
    public int maxEnemiesOnScreen;
    public int totalEnemies;
    public int enemiesPerSpawn;

    int enemiesOnScreen = 0;

    const float spawnDelay = 0.5f;


    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        if(enemiesPerSpawn > 0 && enemiesOnScreen < totalEnemies)
        {
            for(int i = 0; i < enemiesPerSpawn; i++)
            {
                if(enemiesOnScreen < maxEnemiesOnScreen)
                {
                    GameObject newEnemy = Instantiate(enemies[0]) as GameObject;
                    newEnemy.transform.position = spawnPoint.transform.position;
                    enemiesOnScreen += 1;
                }
            }

            yield return new WaitForSeconds(spawnDelay);
            StartCoroutine(Spawn());
        }
    }

    public void removeEnemyFromScreen()
    {
        if(enemiesOnScreen > 0)
        {
            enemiesOnScreen -= 1;
        }
    }
}


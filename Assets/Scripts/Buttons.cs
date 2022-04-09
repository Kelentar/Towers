using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public int count;
    
    public GameObject towerObject;

    public GameObject TowerObject
    {
        get
        {
            return towerObject;
        }
    }
    public void Update()
    {
        if(count == 0)
        {
            Destroy(gameObject);
        }
    }


    //public void CreateSlots()
    //{

    //}

}

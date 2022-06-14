using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    

    //public GameObject towerObject1;
    //public GameObject towerObject2;
    //public GameObject towerObject = null;


    public GameObject[] buildingObject1;
    public GameObject buildingObject = null;

    [SerializeField]
    private UserInterface user;



    //public GameObject TowerObject
    //{
    //    get {
    //        OBj();
    //        return towerObject; 
    //    }
    //}
    public GameObject BuildingObject
    {
        get
        {
            buildingObject = buildingObject1[user.ID];
            return buildingObject;
        }
    }

    
    //public void OBj()
    //{
    //    switch (user.ID)
    //    {
    //        case 0:
                
    //            break;
    //        case 1:
    //            buildingObject = buildingObject1[user.ID];
    //            break;
    //        case 2:
    //            buildingObject = buildingObject1[user.ID];
    //            break;
    //        case 3:
    //            buildingObject = buildingObject1[user.ID];
    //            break;
    //        case 4:
    //            buildingObject = buildingObject1[user.ID];
    //            break;
    //        case 5:
    //            buildingObject = buildingObject1[user.ID];
    //            break;
    //        case 6:
    //            buildingObject = buildingObject1[user.ID];
    //            break;
    //        case 7:
    //            buildingObject = buildingObject1[user.ID];
    //            break;
    //        case 8:
    //            buildingObject = buildingObject1[user.ID];
    //            break;
    //        case 9:
    //            buildingObject = buildingObject1[user.ID];
    //            break;
    //        case 10:
    //            buildingObject = buildingObject1[user.ID];
    //            break;
    //        case 11:
    //            buildingObject = buildingObject1[user.ID];
    //            break;
    //        case 12:
    //            buildingObject = buildingObject1[user.ID];
    //            break;
    //        case 13:
    //            buildingObject = buildingObject1[user.ID];
    //            break;
    //        case 14:
    //            buildingObject = buildingObject1[user.ID];
    //            break;
    //        case 15:
    //            buildingObject = buildingObject1[user.ID];
    //            break;
    //        case 16:
    //            buildingObject = buildingObject1[user.ID];
    //            break;
    //        case 17:
    //            buildingObject = buildingObject1[user.ID];
    //            break;
    //        default:
                
    //            break;

    //    }
    //}
    

    



}

    
    //public void Update()
    //{
    //    if (inventory.amount == 0)
    //    {
    //        gameObject.GetComponent<Buttons>().enabled = false;
    //    }
    //}


    //public void CreateSlots()
    //{

    //}

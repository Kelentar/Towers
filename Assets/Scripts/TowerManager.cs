// Loader для виставлення турелей

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;


public class TowerManager : Loader<TowerManager>
{
    


    [SerializeField]
    Buttons towerBtnPressed;


    
    //public void PlaceTower(RaycastHit2D hit)
    //{
    //    if (!EventSystem.current.IsPointerOverGameObject())
    //    {
    //        GameObject newTower1 = Instantiate(towerBtnPressed.TowerObject);
    //        newTower1.transform.position = hit.transform.position;
    //    }
    //} // Івент для виставлення турелі
    public void PlaceBuilding(RaycastHit2D hit)
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            GameObject newTile1 = Instantiate(towerBtnPressed.BuildingObject);
            newTile1.transform.position = hit.transform.position;
        }
    }
}

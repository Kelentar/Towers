// Loader для виставлення турелей

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class TowerManager : Loader<TowerManager>
{
    Buttons towerBtnPressed;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePoint, Vector2.zero);
            if (hit.collider.tag == "TowerSide")
            {
                hit.collider.tag = "TowerSideFull";
                PlaceTower(hit);

                
            }

        } // Клік для виставлення турелі
    }

    public void PlaceTower(RaycastHit2D hit)
    {
        if (!EventSystem.current.IsPointerOverGameObject() && towerBtnPressed != null)
        {
            GameObject newTower = Instantiate(towerBtnPressed.TowerObject);
            newTower.transform.position = hit.transform.position;
        }
    } // Івент для виставлення турелі

    public void SelectTower(Buttons towerSelected)
    {
        Debug.Log("Кнопку нажав");
        towerBtnPressed = towerSelected;
    } // Кнопка
}

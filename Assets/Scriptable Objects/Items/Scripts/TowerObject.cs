using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TowerType
{
    Food,
    Helmet,
    Weapon,
    Shield,
    Boots,
    Chest,
    Default
}
//public enum Attributes
//{
//    Agility,
//    Intellect,
//    Stamina,
//    Strength
//}

[CreateAssetMenu(fileName = "New Tower", menuName = "Inventory System/Items/tower")]
public class TowerObject : ScriptableObject
{
    public Sprite uiDisplay;
    public bool stackable;
    public TowerType type;
    [TextArea(15, 20)]
    public string description;
    public Tower data = new Tower();

    //public Tower CreateTower()
    //{
    //    //Tower newTower = new Tower(this);
    //    //return newTower;
    //}


}

[System.Serializable]
public class Tower
{
    public string Name;
    public int Id = -1;
    public ItemBuff[] buffs;
    public Tower()
    {
        Name = "";
        Id = -1;
    }
    public Tower(ItemObject item)
    {
        Name = item.name;
        Id = item.data.Id;

    }
}


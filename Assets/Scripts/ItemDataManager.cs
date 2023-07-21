using System.Collections.Generic;
using UnityEngine;

public class ItemDataManager : MonoBehaviour
{

}
public class ItemDataList
{
    public List<ItemData> datas;
}
public class ItemData
{
    public ItemType _type; // 게임 오브젝트 메쉬 종류
    public string _name;   // 게임 오브젝트 이름
    //public float 
}
public enum ItemType
{
    Weapon,
    Armor,
    Consumable,
    Quest,
    Etc
}
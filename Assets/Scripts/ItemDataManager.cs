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
    public ItemType _type; // ���� ������Ʈ �޽� ����
    public string _name;   // ���� ������Ʈ �̸�
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
using System;
using System.IO;
using UnityEngine;
using System.Collections.Generic;

public class ItemParent : MonoBehaviour
{
    protected ItemObj _itemObj;
    protected GameObject _itemGameObject;

    public ItemObj ItemObj => _itemObj;
    public GameObject ItemGameObject => _itemGameObject;
    public void SetItemObj(ItemObj item) => _itemObj = item;
    public void SetItemGameObject(GameObject itemGameObject) => _itemGameObject = itemGameObject;
    public void ItemAction(/*GameObject item*/)
    {
        // 인벤토리에서 Remove를 한다고 치면 해당 아이템의 정보를 인자로 받아와서 생성
        //GenericSingleton<PlayerItemInventory>._instance.GetComponent<PlayerItemInventory>().MoveItem();
        GameObject heroHand = GameObject.Find("Right");
        _itemGameObject.transform.SetParent(heroHand.transform);

        switch (_itemObj._eType)
        {
            case EItemType.Weapon:
                _itemGameObject.transform.localPosition = Vector3.zero;
                _itemGameObject.GetComponent<Pistol>().Equipped();
                break;

            case EItemType.Food:
                _itemGameObject.transform.localPosition = Vector3.zero;
                _itemGameObject.GetComponent<Bread>().Eating();
                break;

            case EItemType.Medicine:
                _itemGameObject.transform.localPosition = Vector3.zero;
                _itemGameObject.GetComponent<Bandage>().FirstAid();
                break;

            default:
                break;
        }
    }
}

[Serializable]
public class ItemObjList
{
    public List<ItemObj> _objs;
}

[Serializable]
public class ItemObj
{
    //public Sprite _sprite;
    public string _name;
    public EItemType _eType;
    public float _scale;
    public int _count;
    public ItemObj(/*Sprite spr,*/ string name, EItemType etype, float scale, int count)
    {
        //_sprite = spr;
        _name = name;
        _eType = etype;
        _scale = scale;
        _count = count;
    }
}
//public class WeaponItem : ItemObj
//{
//    public WeaponItem(/*Sprite spr,*/ string name, EItemType etype, float scale, int count)
//        : base(name, EItemType.Weapon, 1f, 1) { }
//}

public enum EItemType
{
    // 무기
    Weapon,
    // 음식
    Food,
    // 의약품
    Medicine,
}
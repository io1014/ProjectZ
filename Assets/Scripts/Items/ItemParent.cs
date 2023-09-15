using System;
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
    public void ItemAction(EItemType itemType)
    {
        //GameObject heroHand = GameObject.Find("Right");
        //_itemGameObject.transform.SetParent(heroHand.transform);

        switch (itemType)
        {
            case EItemType.Weapon:
                //_itemGameObject.transform.localPosition = Vector3.zero;
                _itemGameObject.GetComponent<Pistol>().IsEquipped(true);
                break;

            case EItemType.Food:
                //_itemGameObject.transform.localPosition = Vector3.zero;
                _itemGameObject.GetComponent<Bread>().Eating(true);
                break;

            case EItemType.Medicine:
                //_itemGameObject.transform.localPosition = Vector3.zero;
                _itemGameObject.GetComponent<Bandage>().FirstAid(true);
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
    public float _weight;
    public float _scale;
    public int _count;
    public ItemObj(/*Sprite spr,*/ string name, EItemType etype, float weight, float scale, int count)
    {
        //_sprite = spr;
        _name = name;
        _eType = etype;
        _weight = weight;
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
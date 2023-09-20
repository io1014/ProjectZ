using System;
using UnityEngine;
using System.Collections.Generic;

public class ItemParent : MonoBehaviour
{
    protected ItemObj _itemObj;
    protected GameObject _itemGameObject;
    public ItemObj ItemObj => _itemObj;
    public GameObject ItemGameObject => _itemGameObject;
    Dictionary<EItemType, List<IItem>> _itemDic;
    public void SetItemObj(ItemObj item) => _itemObj = item;
    public void SetItemGameObject(GameObject itemGameObject) => _itemGameObject = itemGameObject;
    bool _awakeCalled = false;
    private void Start()
    {
        if (!_awakeCalled)
        {
            _itemDic = new Dictionary<EItemType, List<IItem>>();

            List<IItem> weaponItems = new List<IItem>();
            Pistol pistol = new Pistol();
            weaponItems.Add(pistol);
            _itemDic.Add(EItemType.Weapon, weaponItems);

            List<IItem> foodItems = new List<IItem>();
            Bread bread = new Bread();
            foodItems.Add(bread);
            _itemDic.Add(EItemType.Food, foodItems);

            List<IItem> medicItems = new List<IItem>();
            Bandage bandage = new Bandage();
            medicItems.Add(bandage);
            _itemDic.Add(EItemType.Medicine, medicItems);

            Debug.Log("_itemDic initialized with " + _itemDic.Count + " categories.");
            _awakeCalled = true;
            foreach (EItemType key in _itemDic.Keys)
            {
                Debug.Log("Key: " + key.ToString());
            }
        }
    }
    public void UseItem(EItemType itemType)
    {
        //switch (itemType)
        //{
        //    case EItemType.Weapon:
        //        //_itemGameObject.transform.localPosition = Vector3.zero;
        //        _itemGameObject.GetComponent<Pistol>().IsEquipped(true);
        //        break;

        //    case EItemType.Food:
        //        //_itemGameObject.transform.localPosition = Vector3.zero;
        //        _itemGameObject.GetComponent<Bread>().Eating(true);
        //        break;

        //    case EItemType.Medicine:
        //        //_itemGameObject.transform.localPosition = Vector3.zero;
        //        _itemGameObject.GetComponent<Bandage>().FirstAid(true);
        //        break;

        //    default:
        //        break;
        //}
        if(_itemDic.ContainsKey(itemType))
        {
            Debug.Log("itemType: " + itemType);
            List<IItem> items = _itemDic[itemType];

            foreach(IItem item in items)
            {
                item.Use();
            }
        }

    }
}
public interface IItem
{
    void Use();
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
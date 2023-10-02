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

    public virtual void Init(ItemObj obj)
    {

    }

    public void UseItem(EItemType itemType)
    {
        switch (itemType)
        {
            case EItemType.Weapon:
                _itemGameObject.GetComponent<RangedWeapon>().Use();
                break;

            case EItemType.Food:
                _itemGameObject.GetComponent<Food>().Use();
                break;

            case EItemType.Medicine:
                _itemGameObject.GetComponent<Medicine>().Use();
                break;

            default:
                break;
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
    protected ItemObj(/*Sprite spr,*/ string name, EItemType etype, float weight, float scale, int count)
    {
        //_sprite = spr;
        _name = name;
        _eType = etype;
        _weight = weight;
        _scale = scale;
        _count = count;
    }
}

[Serializable]
public class RangedWeaponList
{
    public List<RangedWeaponData> _rangedWeapons;
}
[Serializable]
public class FoodList
{
    public List<FoodData> _foods;
}
[Serializable]
public class MedicineList
{
    public List<MedicineData> _medicines;
}

[Serializable]
public class RangedWeaponData : ItemObj
{
    public int _attackDamage;
    public float _range;
    public float _reloadTime;
    public float _bulletSpeed;
    public int _magAmmo;
    public RangedWeaponType _rwType;

    public RangedWeaponData(string name, EItemType etype, float weight, float scale, int count, int attckDamage, float range, float reloadTime, float bulletSpeed, int magAmmo, RangedWeaponType rwType) 
        : base(name, etype, weight, scale, count)
    {
        _attackDamage = attckDamage;
        _range = range;
        _reloadTime = reloadTime;
        _bulletSpeed = bulletSpeed;
        _magAmmo = magAmmo;
        _rwType = rwType;
    }
}
[Serializable]
public class FoodData : ItemObj
{
    public float _increaseHP;
    public float _increaseFull;
    public FoodType _fType;
    public FoodData(string name, EItemType etype, float weight, float scale, int count, float increaseHP, float increaseFull, FoodType fType)
        : base(name, etype, weight, scale, count)
    {
        _increaseHP = increaseHP;
        _increaseFull = increaseFull;
        _fType = fType;
    }
}
[Serializable]
public class MedicineData : ItemObj
{
    public float _increaseHP;
    public MedicineType _mType;

    public MedicineData(string name, EItemType etype, float weight, float scale, int count, float increaseHP, MedicineType mType)
        : base(name, etype, weight, scale, count)
    {
        _increaseHP = increaseHP;
        _mType = mType;
    }
}
//public class WeaponItem : ItemObj
//{
//    public WeaponItem(/*Sprite spr,*/ string name, EItemType etype, float scale, int count)
//        : base(name, EItemType.Weapon, 1f, 1) { }
//}
[Serializable]
public enum EItemType
{
    // 무기
    Weapon,
    // 음식
    Food,
    // 의약품
    Medicine,
}
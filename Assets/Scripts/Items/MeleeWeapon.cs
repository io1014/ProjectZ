using System;
using UnityEngine;
using UnityEngine.SocialPlatforms;

[Serializable]
public enum MeleeWeaponType
{
    None,
    BaseballBat,
    ButcherKnife,
    Crowbar,
    FireAxe,
    Hammer,
    HeavyWrench,
    Machete,
    Shovel,
    TacticalKnife,
}


public class MeleeWeapon : ItemParent, IItem
{
    string _name = "";
    float _weight;
    int _swingDamage;
    int _swingSpeed;
    float _duration;
    bool _isEquipped = false;
    public MeleeWeaponType _mwType;
    public override void Init(ItemObj data)
    {
        MeleeWeaponData md = (MeleeWeaponData)data;
        _itemObj = data;
        _name = data._name;
        _weight = data._weight;

        _swingDamage = md._swingDamage;
        _swingSpeed = md._swingSpeed;
        _duration = md._duration;
    }
    public void Use()
    {

    }
    private void Start()
    {
        Debug.Log(_name);
    }
}

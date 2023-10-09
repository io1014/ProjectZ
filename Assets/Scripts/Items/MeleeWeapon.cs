using System;
using System.Collections;
using UnityEngine;

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
    float _swingDamageMin;
    float _swingDamageMax;
    float _swingSpeed;
    int _durability;
    bool _isEquipped = false;
    [SerializeField] BoxCollider meleeArea;
    public MeleeWeaponType _mwType;
    public override void Init(ItemObj data)
    {
        MeleeWeaponData md = (MeleeWeaponData)data;
        _itemObj = data;
        _name = data._name;
        _weight = data._weight;

        _swingDamageMin = md._swingDamageMin;
        _swingDamageMax = md._swingDamageMax;
        _swingSpeed = md._swingSpeed;
        _durability = md._durability;
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {

        }
    }
    void Attack()
    {
        if (_isEquipped == false) return;

        StartCoroutine("Swing");
        Animator animator = GetComponent<Animator>();
        animator.SetTrigger("DoSwing");
    }
    public void Use()
    {

    }
    IEnumerator Swing()
    {
        yield return new WaitForSeconds(0.1f);
        meleeArea.enabled = true;

        yield return new WaitForSeconds(0.3f);
        meleeArea.enabled = false;
    }
    public void SetDamage(int damage)
    {
        // 원거리 무기의 damage값 저장
        _swingDamageMax = damage;
    }
    public float getDamage()
    {
        return _swingDamageMax;
    }
}

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
    int _swingDamage = 25;
    int _swingSpeed = 1;
    float _duration;
    bool _isEquipped = false;
    [SerializeField] BoxCollider meleeArea;
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
}

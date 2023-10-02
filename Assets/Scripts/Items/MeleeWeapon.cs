using UnityEngine;

public class MeleeWeapon : ItemParent, IItem
{
    string _name = "";
    float _weight;
    int _attackDamage;
    int _attackSpeed;
    bool _isEquipped = false;
    public void Use()
    {

    }
    private void Start()
    {
        Debug.Log(_name);
    }
}

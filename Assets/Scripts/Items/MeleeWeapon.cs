using UnityEngine;

public class MeleeWeapon : ItemParent, IItem
{
    [SerializeField] protected string _name = "";         
    [SerializeField] float _weight;           
    [SerializeField] int _attackDamage;                      
    [SerializeField] bool _isEquipped = false;
    public void Use()
    {

    }
    private void Start()
    {
        Debug.Log(_name);
    }
}

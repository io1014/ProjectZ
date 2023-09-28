using UnityEngine;

public class BellPepper : ItemParent
{
    string _name = "BellPepper";
    float _weight = 0.1f;
    float _increaseHP = 5f;
    bool _isAte = false;
    HeroStats _playerInfo;
    private void Awake()
    {
        _playerInfo = GetComponent<HeroStats>();
        //_itemObj = new ItemObj(_name, EItemType.Food, _weight, 1f, 1);
    }
    public void Eating(bool isAte)
    {
        _playerInfo.IncHp(_increaseHP);
        IsEating(isAte);
        Invoke("DestroyBread", 1f);
    }
    public void IsEating(bool isAte) => _isAte = isAte;
    void DestroyBread()
    {
        Destroy(gameObject);
    }
}

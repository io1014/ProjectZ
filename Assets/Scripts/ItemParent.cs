using UnityEngine;

public class ItemParent : MonoBehaviour
{
    protected ItemObj _itemObj;
    protected GameObject _itemGameObject;
    public Pistol _pistol;
    public Bread _bread;
    public WireFence _wireFence;
    public Bandage _band;

    public ItemObj ItemObj { get { return _itemObj; } }
    public GameObject ItemGameObject { get { return _itemGameObject; } }
    public void SetItemObj(ItemObj item)
    {
        _itemObj = item;
    }
    public void SetItemGameObject(GameObject itemGameObject)
    {
        _itemGameObject = itemGameObject;
    }
    public void SetPistol(Pistol pistol)
    {
        _pistol = pistol;
    }
    public void SetBread(Bread bread)
    {
        _bread = bread;
    }
    public void SetWirefence(WireFence wireFence)
    {
        _wireFence = wireFence;
    }
    public void SetBand(Bandage band)
    {
        _band = band;
    }
    public void Equip()
    {
        // 자기 종류가 피스톨이면 캐릭터의 손에 피스톨을 만들어 붙인다.
        GameObject heroHand = GameObject.Find("Right");
        _pistol.transform.SetParent(heroHand.transform);
        _pistol.transform.localPosition = Vector3.zero;
        _pistol.equipped();
    }
    public void Eat()
    {
        GameObject heroHand = GameObject.Find("Right");
        _bread.transform.SetParent(heroHand.transform);
        _bread.transform.localPosition = Vector3.zero;
        _bread.Eating();
    }
    public void Heal()
    {
        GameObject heroHand = GameObject.Find("Right");
        _band.transform.SetParent(heroHand.transform);
        _band.transform.localPosition = Vector3.zero;
        _band.Healing();
    }
}
public class ItemObj
{
    //public Sprite _sprite;
    public string _name;
    public EItemType _eType;
    public ItemObj(/*Sprite spr,*/ string name, EItemType etype)
    {
        //_sprite = spr;
        _name = name;
        _eType = etype;
    }
}

public enum EItemType
{
    // 무기
    Weapon,
    // 음식
    Food,
    // 의약품
    Medicine,
}
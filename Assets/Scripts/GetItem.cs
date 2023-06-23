using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    [SerializeField]
    Sprite[] sprites;
    List<ItemObj> items = new List<ItemObj>();
    HeroStats _player;
    List<GameObject> _itemList = new List<GameObject>();
    float _itemRadius = 10;
    private void Start()
    {
        ItemObj itm1 = new ItemObj(sprites[0],"피스톨",EItemType.Pistol);
        items.Add(itm1);
        ItemObj itm2 = new ItemObj(sprites[0], "피스톨", EItemType.Pistol);
        ItemObj itm3 = new ItemObj(sprites[0], "피스톨", EItemType.Pistol);
    }
    void Update()
    {
        // 특정 거리 안에 있는 모든 아이템 목록을 리턴할 수 있는 함수
    }
    public List<GameObject> FindItem()
    {
        // 근처에 있는 아이템 중 특정거리 안에 들어온 아이템들의 리스트를 저장함
        _itemList.Clear();
        GameObject[] _items = GameObject.FindGameObjectsWithTag("Item");
        _player = GetComponent<HeroStats>();
        foreach (var item in _items)
        {
            float distance = Vector3.Distance(_player.transform.position, item.transform.position);
            if(distance <= _itemRadius)
            {
                _itemList.Add(item);
            }
        }
        return _itemList;
    }
    private void OnTriggerEnter(Collider other)
    {
        Vector3 v3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }
    public void RemoveInventory()
    {

    }
}


public class ItemObj
{
    public Sprite _sprite;
    public string _name;
    public EItemType _eType;
    HeroStats _player;
    Pistol _pistol;
    public ItemObj(Sprite spr, string name, EItemType etype)
    {
        _sprite = spr;
        _name = name;
        _eType = etype;
    }
    public void Equip()
    {
        // 자기 종류가 
        // 피스토링면 캐릭터의 손에 피스톨을 만들어 붙인다.
        if(_eType == EItemType.Pistol)
        {
            //캐릭터 손에 피스톨을 만ㄷ르어서 붙인다.
            _pistol._equipped = true;
            GameObject HeroArm = _player.gameObject;
            HeroArm = GameObject.Find("Right");
        }
        else if(_eType == EItemType.Juice)
        {
            //플레이어 갈증을 감소시킨다.
        }
    }
}

public enum EItemType
{
    // 0~ 10 무기
    Pistol,
    // 11 ~ 20 음료
    Juice,
}
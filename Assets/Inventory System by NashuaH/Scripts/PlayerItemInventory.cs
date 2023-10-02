using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerItemInventory :  GenericSingleton<PlayerItemInventory>, IItemHandler
{
    [SerializeField] HouseItemInventory _hInven;
    [SerializeField] CarryItemInventory _carryInven;
    [SerializeField] GameObject _uiItem;
    [SerializeField] Sprite[] _sprites;
    [SerializeField] Transform _content;
    [SerializeField] GameObject _text;  // TrashCan이 켜져 있는지 확인 용
    List<ItemObj> _items = new List<ItemObj>();
    List<GameObject> _itemSlots = new List<GameObject>();
    bool _isText = false;
    int _slotCount = 0;

    public void MoveItem(GameObject itemdata)
    {
        // TrashCan의 text가 false 일 경우 기존대로 실행
        // TrashCan의 text가 true일 경우 버리고 필드 위에 생성하는 코드 실행


        //_itemSet = _item._item;
        if (_text.activeSelf == false)
        {
            _isText = false;
            _items.Remove(itemdata.GetComponent<ItemSlot>()._itemdata);
            _itemSlots.Remove(itemdata);
            //_hInven.AddInventoryItem(itemdata.GetComponent<ItemSlot>()._itemdata);

            EItemType etype = itemdata.GetComponent<ItemSlot>()._itemdata._eType;
            if (etype == EItemType.RangedWeapon || etype == EItemType.MeleeWeapon)
            {
                if (_slotCount >= 1)
                {
                    Debug.Log("return");
                    return;
                }
                else
                {
                    _carryInven.AddInventoryItem(itemdata.GetComponent<ItemSlot>()._itemdata);
                    _slotCount++;
                    Debug.Log("추가된 슬롯카운트 : "+_slotCount);
                }
            }
            else if (etype == EItemType.Food || etype == EItemType.Medicine)
            {
                itemdata.GetComponent<ItemSlot>().OnPlayerInvenButton();
            }
        }
        else if (_text.activeSelf == true)
        {
            _isText = true;
            Debug.Log("Item on Filed");
            _items.Remove(itemdata.GetComponent<ItemSlot>()._itemdata);
            _itemSlots.Remove(itemdata);

            // 필드에 생성하는 코드
            itemdata.GetComponent<ItemSlot>().RemoveItem();
        }
    }

    public void SetText(bool text) => _isText = text;
    public bool GetText() => _isText;
    public void SetSlotCount(int slotCount) => _slotCount = slotCount;
    public int GetSlotCount() => _slotCount;
    public Sprite[] GetSprites() => _sprites;
    public GameObject GetItem() => _uiItem;
    private void Start()
    {
        //ItemObj obj = new ItemObj("Pistol", EItemType.Weapon, 1.5f, 1f, 1);
        //AddInventoryItem(obj);
        //obj = new ItemObj("Bread", EItemType.Food, 0.1f, 1f, 1);
        //AddInventoryItem(obj);
        //obj = new ItemObj("Bandage", EItemType.Medicine, 0.1f, 1f, 1);
        //AddInventoryItem(obj);
    }

    void ShowInven()
    {
        for(int i = 0; i < _items.Count; i++)
        {
            ItemObj itemdata = _items[i];
            _itemSlots[i].GetComponent<ItemSlot>().Init(_items[i], _sprites[(int)itemdata._eType], this, ESlotType.myInven);
        }
    }

    public void AddInventoryItem (ItemObj item)
    {
        GameObject temp = Instantiate(_uiItem, _content);
        _items.Add(item);
        _itemSlots.Add(temp);
        ShowInven();
    }
    public void RemoveInventoryItem(GameObject itemData)
    {
        // 인벤토리에서 클릭을 해서 아이템 사용할 경우
        // 해당 아이템의 리스트에서도 삭제하는 메서드
        // itemData로 들어온 아이템의 리스트를 찾아서 Remove 해야함
        _items.Remove(itemData.GetComponent<ItemSlot>()._itemdata);
        _itemSlots.Remove(itemData);
    }
}

public interface IItemHandler
{
    void MoveItem(GameObject itemData);
}
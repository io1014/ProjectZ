using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarryItemInventory : GenericSingleton<CarryItemInventory>, IItemHandler
{

    [SerializeField] PlayerItemInventory _pInven;
    [SerializeField] GameObject _carryItem;
    [SerializeField] Sprite[] _sprites;
    [SerializeField] Transform _content;
    List<ItemObj> _items = new List<ItemObj>();
    List<GameObject> _itemSlots = new List<GameObject>();
    int _slotCount = 0;
    Button _btn;

    public void MoveItem(GameObject itemdata)
    {
        //_itemSet = _item._item;
        //GameObject heroHand = GameObject.Find("Right");
        //heroHand.transform.GetChild(0);

        _pInven.AddInventoryItem(itemdata.GetComponent<ItemSlot>()._itemdata);
        _items.Remove(itemdata.GetComponent<ItemSlot>()._itemdata);
        _itemSlots.Remove(itemdata);
        if(_slotCount <= 0) _slotCount = 0;
        else _slotCount--;
    }

    private void Start()
    {
        ItemObj obj = new ItemObj("Pistol", EItemType.Weapon, 1f, 1);
        AddInventoryItem(obj);
        _slotCount++;
    }
    public int GetSlotCount()
    {
        return _slotCount;
    }

    void ShowInven()
    {
        for (int i = 0; i < _items.Count; i++)
        {
            ItemObj itemdata = _items[i];
            _itemSlots[i].GetComponent<ItemSlot>().Init(_items[i], _sprites[(int)itemdata._eType], this, ESlotType.CarryInven);
        }
    }

    public void AddInventoryItem(ItemObj item)
    {
        if (_slotCount >= 1) _slotCount = 1;
        else _slotCount++;
        GameObject temp = Instantiate(_carryItem, _content);
        _items.Add(item);
        _itemSlots.Add(temp);
        ShowInven();
    }

    public interface IItemHandler
    {
        void MoveItem(GameObject itemData);
    }
}

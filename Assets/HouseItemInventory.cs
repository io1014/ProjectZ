using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HouseItemInventory : GenericSingleton<HouseItemInventory>, IItemHandler
{
    [SerializeField] PlayerItemInventory _pInven;
    [SerializeField] GameObject _houseItem;
    [SerializeField] Sprite[] _sprites;
    [SerializeField] Transform _content;
    List<ItemObj> _items = new List<ItemObj>();
    List<GameObject> _itemSlots = new List<GameObject>();

    // Start is called before the first frame update
    private void Start()
    {
        ItemObj obj = new ItemObj("Pistol", EItemType.Weapon);
        AddInventoryItem(obj);
        obj = new ItemObj("Bread", EItemType.Food);
        AddInventoryItem(obj);
        obj = new ItemObj("Bandage", EItemType.Medicine);
        AddInventoryItem(obj);
    }

    void ShowInven()
    {
        for (int i = 0; i < _items.Count; i++)
        {
            ItemObj itemdata = _items[i];
            _itemSlots[i].GetComponent<ItemSlot>().Init(_items[i], _sprites[(int)itemdata._eType], this);
        }
    }

    public void AddInventoryItem(ItemObj item)
    {
        GameObject temp = Instantiate(_houseItem, _content);
        _items.Add(item);
        _itemSlots.Add(temp);
        ShowInven();

    }

    public void MoveItem(GameObject itemdata)
    {
        _items.Remove(itemdata.GetComponent<ItemSlot>()._itemdata);
        _itemSlots.Remove(itemdata);
        _pInven.AddInventoryItem(itemdata.GetComponent<ItemSlot>()._itemdata);
    }
}

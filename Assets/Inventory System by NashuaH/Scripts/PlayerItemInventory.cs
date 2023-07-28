using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerItemInventory :  GenericSingleton<PlayerItemInventory>, IItemHandler
{
    [SerializeField] HouseItemInventory _hInven;
    [SerializeField] GameObject _uiItem;
    [SerializeField] Sprite[] _sprites;
    [SerializeField] Transform _content;
    List<ItemObj> _items = new List<ItemObj>();
    List<GameObject> _itemSlots = new List<GameObject>();

    public void MoveItem(GameObject itemdata)
    {
        //_itemSet = _item._item;
        _items.Remove(itemdata.GetComponent<ItemSlot>()._itemdata);
        _itemSlots.Remove(itemdata);
        _hInven.AddInventoryItem(itemdata.GetComponent<ItemSlot>()._itemdata);
    }

    private void Start()
    {
        ItemObj obj = new ItemObj("Pistol", EItemType.Weapon, 1f, 1);
        AddInventoryItem(obj);
        obj = new ItemObj("Bread", EItemType.Food, 1f, 1);
        AddInventoryItem(obj);
        obj = new ItemObj("Bandage", EItemType.Medicine, 1f, 1);
        AddInventoryItem(obj);
    }

    void ShowInven()
    {
        for(int i = 0; i < _items.Count; i++)
        {
            ItemObj itemdata = _items[i];
            _itemSlots[i].GetComponent<ItemSlot>().Init(_items[i], _sprites[(int)itemdata._eType], this);
        }
    }

    public void AddInventoryItem (ItemObj item)
    {
        GameObject temp = Instantiate(_uiItem, _content);
        _items.Add(item);
        _itemSlots.Add(temp);
        ShowInven();
    }
    //public GameObject RemoveInventoryItem(itemdata)
    //{
    //    _items.Remove(itemdata.GetComponent<ItemSlot>()._itemdata);
    //    _itemSlots.Remove(itemdata);
    //    return itemdata;
    //}
}

public interface IItemHandler
{
    void MoveItem(GameObject itemData);
}
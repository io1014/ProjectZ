using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class HouseItemInventory : GenericSingleton<HouseItemInventory>, IItemHandler
{
    [SerializeField] PlayerItemInventory _pInven;
    [SerializeField] GameObject _houseItem;
    [SerializeField] Sprite[] _sprites;
    [SerializeField] Transform _content;
    public List<ItemObj> _items = new List<ItemObj>();
    List<GameObject> _itemSlots = new List<GameObject>();

    // Start is called before the first frame update
    private void Start()
    {
        //ItemObj obj = new ItemObj("Pistol", EItemType.Weapon, 1f, 1);
        //AddInventoryItem(obj);
        //obj = new ItemObj("Bread", EItemType.Food, 1f, 1);
        //AddInventoryItem(obj);
        //obj = new ItemObj("Bandage", EItemType.Medicine, 1f, 1);
        //AddInventoryItem(obj);
        //obj = new ItemObj("can_food", EItemType.Weapon, 1f, 1);
        //AddInventoryItem(obj);

    }
    void ShowInven()
    {
        for (int i = 0; i < _itemSlots.Count; i++)
        {
            ItemObj itemdata = _items[i];
            _itemSlots[i].GetComponent<ItemSlot>().Init(_items[i], _sprites[(int)itemdata._eType], this, ESlotType.houseInven);
        }
    }

    public void AddHouseItemInven(List<GameObject> _objs)
    {
        _items.Clear();
        foreach(GameObject obj in _itemSlots)
        {
            Destroy(obj);
        }
        _itemSlots.Clear();
        foreach(GameObject obj in _objs)
        {
            AddInventoryItem(obj.GetComponent<ItemParent>().ItemObj);
        }
        gameObject.SetActive(true);
        _pInven.gameObject.SetActive(true);
    }

    public void AddInventoryItem(ItemObj item)
    {
        Debug.Log(item._eType);
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

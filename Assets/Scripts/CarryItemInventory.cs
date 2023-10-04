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
    public void MoveItem(GameObject itemdata)
    {
        //_itemSet = _item._item;
        //GameObject heroHand = GameObject.Find("Right");
        //heroHand.transform.GetChild(0);
        PlayerItemInventory myInven = GenericSingleton<PlayerItemInventory>._instance.GetComponent<PlayerItemInventory>();

        int slotCount = myInven.GetSlotCount();
        slotCount--;
        myInven.SetSlotCount(slotCount);
        Debug.Log("갱신된 슬롯카운트 : "+slotCount);

        if(/* sprites의 name이 pistol이면*/ true)
        {
            // 
        }
        
        _pInven.AddInventoryItem(itemdata.GetComponent<ItemSlot>()._itemdata);
        _items.Remove(itemdata.GetComponent<ItemSlot>()._itemdata);
        _itemSlots.Remove(itemdata);
        GameObject temp = GameObject.Find("Rweaponholder");
        GameObject weapon = temp.transform.GetChild(0).gameObject;
        Destroy(weapon);
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

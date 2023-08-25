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
    [SerializeField] GameObject _text;  // TrashCan�� ���� �ִ��� Ȯ�� ��
    List<ItemObj> _items = new List<ItemObj>();
    List<GameObject> _itemSlots = new List<GameObject>();

    public void MoveItem(GameObject itemdata)
    {
        // TrashCan�� text�� false �� ��� ������� ����
        // TrashCan�� text�� true�� ��� ������ �ʵ� ���� �����ϴ� �ڵ� ����


        //_itemSet = _item._item;
        if (_text.activeSelf == false)
        {
            _items.Remove(itemdata.GetComponent<ItemSlot>()._itemdata);
            _itemSlots.Remove(itemdata);
            //_hInven.AddInventoryItem(itemdata.GetComponent<ItemSlot>()._itemdata);

            EItemType etype = itemdata.GetComponent<ItemSlot>()._itemdata._eType;
            if (etype == EItemType.Weapon)
            {
                _carryInven.AddInventoryItem(itemdata.GetComponent<ItemSlot>()._itemdata);
            }
            else if (etype == EItemType.Food || etype == EItemType.Medicine)
            {
                itemdata.GetComponent<ItemSlot>().OnPlayerInvenButton();
            }
        }
        else if (_text.activeSelf == true)
        {
            Debug.Log("Item on Filed");
            _items.Remove(itemdata.GetComponent<ItemSlot>()._itemdata);
            _itemSlots.Remove(itemdata);

            // �ʵ忡 �����ϴ� �ڵ�
        }
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
        // �κ��丮���� Ŭ���� �ؼ� ������ ����� ���
        // �ش� �������� ����Ʈ������ �����ϴ� �޼���
        // itemData�� ���� �������� ����Ʈ�� ã�Ƽ� Remove �ؾ���
        _items.Remove(itemData.GetComponent<ItemSlot>()._itemdata);
        _itemSlots.Remove(itemData);
    }
}

public interface IItemHandler
{
    void MoveItem(GameObject itemData);
}
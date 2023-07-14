using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerItemInventory : GenericSingleton<PlayerItemInventory>


{
    [SerializeField] GameObject _uiItem;
    [SerializeField] Sprite[] _sprites;
    ItemObj _item;
    ItemObj _itemSet { set { _itemSet = value; } }

    private void Start()
    {
        _itemSet = _item._item;
    }
    public void AddInventoryItem (GameObject item)
    {
        GameObject temp = null;
        Image tempImg = temp.GetComponentsInChildren<Image>()[0];

        //if(data._type == EItemType.Bread)
        //{
        //    // content - button - slot - ItemImage¿« image∫Ø∞Ê
        //    tempImg.sprite = _sprites[0];
        //}
        //else if(data._type == EItemType.Pistol)
        //{

        //}


    }



}

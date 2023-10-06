using System;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    List<ItemObj> _itemList = new List<ItemObj>();
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            FindItem();
        }
    }
    public List<ItemObj> FindItem()
    {
        if(Physics.CheckSphere(transform.position, 1, 1 << LayerMask.NameToLayer("Item")))
        {
           Collider[] items = Physics.OverlapSphere(transform.position, 1, 1 << LayerMask.NameToLayer("Item"));
           for (int i = 0; i < items.Length; i++)
           {
                GameObject itemObject = items[i].gameObject;
                ItemObj itemInfo = itemObject.GetComponent<ItemType>().ItemObj;
                _itemList.Add(itemInfo);
                PlayerItemInventory myInven = GenericSingleton<PlayerItemInventory>._instance.GetComponent<PlayerItemInventory>();
                float maxWeight = myInven.GetMaxWeight();
                if (myInven._currentWeight >= maxWeight)
                {
                    Debug.Log("아이템을 획득하지 못하였습니다." + "(" + itemInfo._name + ")");
                    return _itemList;
                }
                else
                {
                    myInven.AddInventoryItem(itemInfo);
                    Destroy(items[i].gameObject);
                    Debug.Log("아이템을 획득하였습니다. " + "("+ itemInfo._name+ ")" );
                }
            }
        }
        return _itemList;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 1);
    }
}
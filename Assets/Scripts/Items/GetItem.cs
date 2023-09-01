using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    List<ItemObj> _itemList = new List<ItemObj>();
    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }
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
                GenericSingleton<PlayerItemInventory>._instance.GetComponent<PlayerItemInventory>().AddInventoryItem(itemInfo);
                Destroy(items[i].gameObject);
                Debug.Log("æ∆¿Ã≈€¿ª »πµÊ«œºÃΩ¿¥œ¥Ÿ. ");
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
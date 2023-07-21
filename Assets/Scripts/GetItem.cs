using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{

    [SerializeField] Sprite[] sprites;
    HeroStats _player;
    List<GameObject> _itemList = new List<GameObject>();
    float _itemRadius = 10;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            FindItem();
            //RaycastHit hit;
            //Ray ray = new Ray(transform.position, transform.forward);
            //if (Physics.Raycast(ray, out hit, 3, 1 << LayerMask.NameToLayer("Item")))
            //{
            //    foreach(var item in _itemList)
            //    {
            //        _itemList.Remove(item);
            //        Destroy(hit.collider.gameObject);
            //    }
            //}
        }
    }
    public List<GameObject> FindItem()
    {
        //// 근처에 있는 아이템 중 특정거리 안에 들어온 아이템들의 리스트를 저장함
        //_itemList.Clear();
        //GameObject[] _items = GameObject.FindGameObjectsWithTag("Item");
        //// Item 태그로 찾지말고, 수업 때 배운 좀비처럼 주변에 Physics.OverlapSphere를 이용해서 만들기
        //_player = GetComponent<HeroStats>();
        //foreach (var item in _items)
        //{
        //    float distance = Vector3.Distance(_player.transform.position, item.transform.position);
        //    if(distance <= _itemRadius)
        //    {
        //        _itemList.Add(item);
        //        //GenericSingleton<PlayerItemInventory>._instance.GetComponent<PlayerItemInventory>().AddInventoryItem(item);
        //    }
        //}
        //return _itemList;

        if(Physics.CheckSphere(transform.position, 1, 1 << LayerMask.NameToLayer("Item")))
        {
           Collider[] items = Physics.OverlapSphere(transform.position, 1, 1 << LayerMask.NameToLayer("Item"));
           for (int i = 0; i < items.Length; i++)
           {
                _itemList.Add(items[i].gameObject /* gameObject를 넣지말고, gameObject 안에 있는 ItemObj를 넣어야함*/);
                Destroy(items[i].gameObject);
                Debug.Log(items[i]);
                //GenericSingleton<PlayerItemInventory>._instance.GetComponent<PlayerItemInventory>().AddInventoryItem(/*획득한 아이템의 ItemObj 정보를 인벤에 전달*/);
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
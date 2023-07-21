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
        //// ��ó�� �ִ� ������ �� Ư���Ÿ� �ȿ� ���� �����۵��� ����Ʈ�� ������
        //_itemList.Clear();
        //GameObject[] _items = GameObject.FindGameObjectsWithTag("Item");
        //// Item �±׷� ã������, ���� �� ��� ����ó�� �ֺ��� Physics.OverlapSphere�� �̿��ؼ� �����
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
                _itemList.Add(items[i].gameObject /* gameObject�� ��������, gameObject �ȿ� �ִ� ItemObj�� �־����*/);
                Destroy(items[i].gameObject);
                Debug.Log(items[i]);
                //GenericSingleton<PlayerItemInventory>._instance.GetComponent<PlayerItemInventory>().AddInventoryItem(/*ȹ���� �������� ItemObj ������ �κ��� ����*/);
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
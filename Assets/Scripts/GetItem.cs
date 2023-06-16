using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    GameObject _player;
    List<GameObject> _itemList = new List<GameObject>();
    float _itemRadius = 10;
    void Update()
    {
        // Ư�� �Ÿ� �ȿ� �ִ� ��� ������ ����� ������ �� �ִ� �Լ�
        //FindItem();
    }
    public List<GameObject> FindItem()
    {
        _itemList.Clear();
        GameObject[] _items = GameObject.FindGameObjectsWithTag("Item");
        foreach(var item in _items)
        {
            float distance = Vector3.Distance(_player.transform.position, item.transform.position);
            if(distance <= _itemRadius)
            {
                _itemList.Add(item);
            }
        }
        return _itemList;
    }
}

//public class BowData
//{
//    // Sprite  asset resource
//    // string
//    // distance
//    // damage
//    // ������
//    // 
//}
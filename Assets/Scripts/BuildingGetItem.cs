using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGetItem : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] GameObject[] _items;
    

    float _inject;
    List<GameObject> _itemsList;

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(_player.transform.position, transform.position);
        if (dist <= 3f && Input.GetKeyDown(KeyCode.F))//if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log(dist + " , "+gameObject.name);
            GetInject();
        }
    }


    void GetItem()
    {
       _itemsList = new List<GameObject>();
        for(int i = 0; i < _items.Length; i++) 
        {
            _itemsList.Add(_items[i]);
        }
        

        
       
    }

    void GetInject()
    {
        _inject = Random.Range(1,12);

        if (_inject >= 1 && _inject < 6)
        {
            Debug.Log("좀비한테 물리지 않았습니다.");
        }
        else if (_inject >=6 && _inject < 9)
        {
            Debug.Log("좀비한테 물려 약간의 데미지를 입습니다.");
        }
        else if( _inject >= 9 && _inject < 11 )
        {
            Debug.Log("좀비한테 물려 데미지를 입습니다.");
        }
        else if( _inject ==11)
            {
            Debug.Log("좀비한테 물려 큰 데미지를 입습니다.");
        }
        else
        {
            Debug.Log("오류가 발생하였습니다.");
        }
        

    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGetItem : MonoBehaviour
{
    
    [SerializeField] GameObject[] _items;
    [SerializeField] Building _buildingType;
     HeroStats _heroStats;


    float _inject;
    List<GameObject> _itemsList;
    
    ItemFromBuidling _IFB;

    // Update is called once per frame
    void Update()
    {
        /*float dist = Vector3.Distance(_player.transform.position, transform.position);
        if (dist <= 2f && Input.GetKeyDown(KeyCode.F))//if (Input.GetKeyDown(KeyCode.F))
        {
            int bite = Random.Range(20, 60);
            Debug.Log(dist + " , "+gameObject.name);
            InvokeRepeating("GetInject", 10, bite);
        }
        else if (dist > 2f)
        {
            CancelInvoke("GetInject");
        }
        */
        GetItem();
    }


    void GetItem()
    {
        GameObject _player = GameObject.FindGameObjectWithTag("Hero");
        float dist = Vector3.Distance(_player.transform.position, transform.position);
        if(dist <= 2f && Input.GetKeyDown(KeyCode.F))
        {
            int bite = Random.Range(20, 60);
            Debug.Log(dist + " , " + gameObject.name);
            InvokeRepeating("GetInject", 10, bite);
            switch (_buildingType)
            {
                case Building.Factory: Factory();break;
                case Building.Hospital:Hospital();break;
                    case Building.GasStation:GasStation();break;
                    case Building.FireDepartment:FireDepartment();break;    
                    case Building.Store:Store();break;  
                    case Building.House:House();break;
                default:break;


            }
            

        }
        else if (dist > 2f)
        {
            CancelInvoke("GetInject");
        }

    }

    void Factory()
    {
        _itemsList = new List<GameObject>();
        Building FI = Building.Factory;      //FI = Factory Item
        if(FI == _buildingType)              // 만약 각 건물에 설정한 type이랑 함수에 enum이 같으면 
        {
            int randomItemCount = Random.Range(2, 9);       // 랜덤한 카운트를 센다
            for (int i = 0; i < randomItemCount; i++)       // 랜덤한 카운트 만큼 반복한다
            {
                int randomItem = Random.Range(0, _itemsList.Count);    // 0에서 아이템 리스트에 카운트만큼 순서를 뽑는다
                _itemsList.Add(_items[randomItem]);                    // 그 순서를 정하여 아이템 리스트에 추가한다 
            }
        }
        
    }

    void Store()
    {
        _itemsList = new List<GameObject>();
        Building SI = Building.Store;
        if(SI == _buildingType)
        {
            for (int i = 0; i < _items.Length; i++)
            {
                _itemsList.Add(_items[i]);
            }
        }
    }

    void Hospital()
    {
        _itemsList = new List<GameObject>();
            Building HSI = Building.Hospital;
            if(HSI == _buildingType)
            {
                for(int i = 0; i < _items.Length; i++)
                {
                    _itemsList.Add(_items[i]);  
                }
            }
        
    }


    void House()
    {
        _itemsList = new List<GameObject>();
        Building HI = Building.House;
        if(HI == _buildingType) 
        {
            for(int i = 0; i < _items.Length;i++)
            {
                _itemsList.Add(_items[i]);  
            }
        }
       
    }


    void FireDepartment()
    {
        _itemsList = new List<GameObject>();
        Building FI = Building.FireDepartment;
        if( FI == _buildingType) 
        {
            for(int i =0; i < _items.Length; i++)
            {
                _itemsList.Add(_items[i]);  
            }
        }
    }

    void GasStation()
    {
        _itemsList = new List<GameObject>();
        Building GI = Building.GasStation;  
        if( GI == _buildingType) 
        {
            for(int i = 0; i< _items.Length; i++)
            {
                _itemsList.Add(_items[i]);  
            }
        }
    }


    void GetInject()
    {
        _inject = Random.Range(1,12);
        int dmg = 5;
        int Littledmg = 3;
        int Bigdmg = 10;

        
        if (_inject >= 1 && _inject < 6)
        {
          
            Debug.Log("좀비한테 물리지 않았습니다.");
        }
        else if (_inject >=6 && _inject < 9)
        {
            _heroStats.Damage(Littledmg);
            Debug.Log("좀비한테 물려 약간의 데미지를 입습니다.");
        }
        else if( _inject >= 9 && _inject < 11 )
        {
            _heroStats.Damage(dmg);
            Debug.Log("좀비한테 물려 데미지를 입습니다.");
        }
        else if( _inject ==11)
            {
            _heroStats.Damage(Bigdmg);
            Debug.Log("좀비한테 물려 큰 데미지를 입습니다.");
        }
        else
        {

            Debug.Log("오류가 발생하였습니다.");
        }


    }



    public enum Building
    {
        Factory,
        Store,
        Hospital,
        House,
        FireDepartment,
        GasStation
    }



}


public delegate void ItemFromBuidling();

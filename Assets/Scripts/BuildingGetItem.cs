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
        if(FI == _buildingType)              // ���� �� �ǹ��� ������ type�̶� �Լ��� enum�� ������ 
        {
            int randomItemCount = Random.Range(2, 9);       // ������ ī��Ʈ�� ����
            for (int i = 0; i < randomItemCount; i++)       // ������ ī��Ʈ ��ŭ �ݺ��Ѵ�
            {
                int randomItem = Random.Range(0, _itemsList.Count);    // 0���� ������ ����Ʈ�� ī��Ʈ��ŭ ������ �̴´�
                _itemsList.Add(_items[randomItem]);                    // �� ������ ���Ͽ� ������ ����Ʈ�� �߰��Ѵ� 
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
          
            Debug.Log("�������� ������ �ʾҽ��ϴ�.");
        }
        else if (_inject >=6 && _inject < 9)
        {
            _heroStats.Damage(Littledmg);
            Debug.Log("�������� ���� �ణ�� �������� �Խ��ϴ�.");
        }
        else if( _inject >= 9 && _inject < 11 )
        {
            _heroStats.Damage(dmg);
            Debug.Log("�������� ���� �������� �Խ��ϴ�.");
        }
        else if( _inject ==11)
            {
            _heroStats.Damage(Bigdmg);
            Debug.Log("�������� ���� ū �������� �Խ��ϴ�.");
        }
        else
        {

            Debug.Log("������ �߻��Ͽ����ϴ�.");
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

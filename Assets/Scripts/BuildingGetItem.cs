using System;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGetItem : MonoBehaviour
{

    [SerializeField] Building _buildingType;
     HeroStats _heroStats;

    public static BuildingGetItem instance;

    bool _isContacted = false;
    bool _rooted = false;
    bool _add = false;
    float _inject;
    public GameObject[] _items;
    public List<GameObject> _itemList = new List<GameObject>();
    public bool _far = false;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _heroStats = new HeroStats();
        _items = GameObject.Find("LoadFile").GetComponent<LoadFile>().Items;
        
        Factory();
        Hospital();
        FireDepartment();
        Store();
        House();
    }


    void Update()
    {
        GetItem();
    }


    void GetItem()
    {
        GameObject _player = GameObject.FindGameObjectWithTag("Hero");
        float dist = Vector3.Distance(_player.transform.position, transform.position);
        if (_isContacted==false&& dist <= 1f && Input.GetKeyDown(KeyCode.G))
        {
            StartMusic.instance.DoorOpen();
            GenericSingleton<HouseItemInventory>._instance.gameObject.SetActive(true);
            GenericSingleton<HouseItemInventory>._instance.gameObject.GetComponent<Animator>().SetBool("Open", true);
            _isContacted = true;
            int bite = UnityEngine.Random.Range(20, 60);
            Debug.Log(dist + " , " + gameObject.name + gameObject.tag + _buildingType + "�� �����߽��ϴ�.");
            InvokeRepeating("GetInject", 10, bite);
            switch (_buildingType)
            {
                //case Building.Factory: Factory(); break;
                //case Building.Hospital: Hospital(); break;
                //case Building.FireDepartment: FireDepartment(); break;
                //case Building.Store: Store(); break;
                //case Building.House: House(); break;
                default: break;

            }
            if(_rooted == false)
            {
                GenericSingleton<HouseItemInventory>._instance.GetComponent<HouseItemInventory>().AddHouseItemInven(_itemList);
                _rooted = true;
            }
            

        }
        if (GenericSingleton<HouseItemInventory>._instance.GetComponent<HouseItemInventory>()._Looted == true)
        {
            Debug.Log(_itemList.Count);
            _itemList.Clear();
            GenericSingleton<HouseItemInventory>._instance.GetComponent<HouseItemInventory>()._Looted = false;
        }


        else if (_isContacted == true && dist >2f ) 
        {
            GameObject.Find("InventoryInHouse").GetComponent<Animator>().SetBool("Open", false);
            CancelInvoke("GetInject");
            _isContacted = false;
            _far = true;
        }
       


    }

    void Factory()
    { 
        if(_add == false)
        {
             Building FI = Building.Factory;      //FI = Factory Item
            _itemList = new List<GameObject>();
            if (FI == _buildingType)              // ���� �� �ǹ��� ������ type�̶� �Լ��� enum�� ������ 
            {
                int randomItemCount = UnityEngine.Random.Range(3, 5);       // ������ ī��Ʈ�� ����
                for (int i = 0; i < randomItemCount; i++)       // ������ ī��Ʈ ��ŭ �ݺ��Ѵ�
                {
                    int randomItem = UnityEngine.Random.Range(0, 52);    // 0���� ������ ����Ʈ�� ī��Ʈ��ŭ ������ �̴´�
                    _itemList.Add(_items[randomItem]);                    // �� ������ ���Ͽ� ������ ����Ʈ�� �߰��Ѵ�  
                }
                int randomWeaponCount = UnityEngine.Random.Range(1, 5);
                for(int i = 0; i < randomWeaponCount; i++)
                {
                    int randomItem = UnityEngine.Random.Range(53, 62);
                    _itemList.Add(_items[randomItem]);
                }
                _add = true;
            }
        }
        
    }

    void Store()
    {
       if(_add == false)
        {
            Building SI = Building.Store;
            _itemList = new List<GameObject>();
            if (SI == _buildingType)              // ���� �� �ǹ��� ������ type�̶� �Լ��� enum�� ������ 
            {
                int randomItemCount = UnityEngine.Random.Range(2, 9);       // ������ ī��Ʈ�� ����
                for (int i = 0; i < randomItemCount; i++)       // ������ ī��Ʈ ��ŭ �ݺ��Ѵ�
                {
                    int randomItem = UnityEngine.Random.Range(i, 52);    // 0���� ������ ����Ʈ�� ī��Ʈ��ŭ ������ �̴´�
                    _itemList.Add(_items[randomItem]);                    // �� ������ ���Ͽ� ������ ����Ʈ�� �߰��Ѵ� 
                }
                _add = true;
            }
        }
    }

    void Hospital()
    {
        if (_add == false)
        {
            _itemList = new List<GameObject>();
            Building HSI = Building.Hospital;
            if (HSI == _buildingType)              // ���� �� �ǹ��� ������ type�̶� �Լ��� enum�� ������ 
            {
                int randomItemCount = UnityEngine.Random.Range(2, 15);       // ������ ī��Ʈ�� ����
                for (int i = 1; i < randomItemCount; i++)       // ������ ī��Ʈ ��ŭ �ݺ��Ѵ�
                {
                    int randomItem = UnityEngine.Random.Range(i, 52);    // 0���� ������ ����Ʈ�� ī��Ʈ��ŭ ������ �̴´�
                    _itemList.Add(_items[randomItem]);                    // �� ������ ���Ͽ� ������ ����Ʈ�� �߰��Ѵ� 
                }
                _itemList.Add(_items[2]);
                _itemList.Add(_items[2]);
                _itemList.Add(_items[2]);
                _add = true;
            }
        }
        

    }


    void House()
    {
        if(_add == false)
        {
            _itemList = new List<GameObject>();
            Building HI = Building.House;
            if (HI == _buildingType)              // ���� �� �ǹ��� ������ type�̶� �Լ��� enum�� ������ 
            {
                
                int gunrandom = UnityEngine.Random.Range(1, 10);
                if (gunrandom < 7)
                {
                    _itemList.Add(_items[0]);
                }
                int randomItemCount = UnityEngine.Random.Range(4, 9);       // ������ ī��Ʈ�� ����
                for (int i = 0; i < randomItemCount; i++)       // ������ ī��Ʈ ��ŭ �ݺ��Ѵ�
                {
                    int randomItem = UnityEngine.Random.Range(1, 54);    // 0���� ������ ����Ʈ�� ī��Ʈ��ŭ ������ �̴´�
                    _itemList.Add(_items[randomItem]);                    // �� ������ ���Ͽ� ������ ����Ʈ�� �߰��Ѵ� 
                }
                _add = true;
            }

        }

    }


    void FireDepartment()
    {
        if (_add == false)
        {
            _itemList = new List<GameObject>();
            Building FaI = Building.FireDepartment;
            if (FaI == _buildingType)              // ���� �� �ǹ��� ������ type�̶� �Լ��� enum�� ������ 
            {
                int randomItemCount = UnityEngine.Random.Range(2, 6);       // ������ ī��Ʈ�� ����
                for (int i = 0; i < randomItemCount; i++)       // ������ ī��Ʈ ��ŭ �ݺ��Ѵ�
                {
                    int randomItem = UnityEngine.Random.Range(i, 52);    // 0���� ������ ����Ʈ�� ī��Ʈ��ŭ ������ �̴´�
                    _itemList.Add(_items[randomItem]);                    // �� ������ ���Ͽ� ������ ����Ʈ�� �߰��Ѵ� 
                }
                _itemList.Add(_items[55]);
                _itemList.Add(_items[56]);
                _itemList.Add(_items[57]);
                _add = true;
            }
        }
       
    }



    void GetInject()
    {
        _inject = UnityEngine.Random.Range(1,12);
        float dmg = 5;
        float Littledmg = 3;
        float Bigdmg = 10;

        
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

    public void MoveItem(GameObject itemData)
    {
        throw new NotImplementedException();
    }

    [Serializable]
    public enum Building
    {
        Factory,
        Store,
        Hospital,
        House,
        FireDepartment,
    }

}


public delegate void ItemFromBuidling();

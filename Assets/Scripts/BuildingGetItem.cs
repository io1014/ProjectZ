using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGetItem : MonoBehaviour
{



    
    [SerializeField] Building _buildingType;
     HeroStats _heroStats;
    GameObject _hero;

    public static BuildingGetItem instance;

    bool _isContacted = false;
    bool _rooted = false;
    float _inject;
   public GameObject[] _items;
    public List<GameObject> _itemList = new List<GameObject>();
   public bool _far = false;

    ItemFromBuidling _IFB;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _heroStats = new HeroStats();
        _items = GameObject.Find("LoadFile").GetComponent<LoadFile>().Items;
        
 
        
    }

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
        if (_isContacted==false&& dist <= 2f && Input.GetKeyDown(KeyCode.G))
        {
            //GameObject.Find("InventoryInHouse").GetComponent<Animator>().SetBool("Open", true);
            GenericSingleton<HouseItemInventory>._instance.gameObject.SetActive(true);
           GenericSingleton<HouseItemInventory>._instance.gameObject.GetComponent<Animator>().SetBool("Open", true);
            _isContacted = true;
            int bite = UnityEngine.Random.Range(20, 60);
            Debug.Log(dist + " , " + gameObject.name + gameObject.tag + _buildingType + "�� �����߽��ϴ�.");
            InvokeRepeating("GetInject", 10, bite);
            switch (_buildingType)
            {
                case Building.Factory: Factory(); break;
                case Building.Hospital: Hospital(); break;
                case Building.FireDepartment: FireDepartment(); break;
                case Building.Store: Store(); break;
                case Building.House: House(); break;
                default: break;

            }
            foreach (var obj in _itemList)
            {
                obj.GetComponent<ItemParent>().Init();
            }
            GenericSingleton<HouseItemInventory>._instance.GetComponent<HouseItemInventory>().AddHouseItemInven(_itemList);
            if (GenericSingleton<HouseItemInventory>._instance.GetComponent<HouseItemInventory>()._Looted == true)
            {
                _itemList.Clear();
                Debug.Log("���ÿϷ�");
                

            }





        }
        else if (_isContacted == true && dist >2f ) 
        {
            
             Debug.Log("�־������ϴ�");
             _isContacted = false;
            GameObject.Find("InventoryInHouse").GetComponent<Animator>().SetBool("Open", false);
            CancelInvoke("GetInject");
            _far = true;




        }
       


    }

    void Factory()
    {
         
        
        if(_rooted == false)
        {
            Building FI = Building.Factory;      //FI = Factory Item
            _itemList = new List<GameObject>();
            if (FI == _buildingType)              // ���� �� �ǹ��� ������ type�̶� �Լ��� enum�� ������ 
            {
                int randomItemCount = UnityEngine.Random.Range(2, 9);       // ������ ī��Ʈ�� ����
                for (int i = 0; i < randomItemCount; i++)       // ������ ī��Ʈ ��ŭ �ݺ��Ѵ�
                {
                    int randomItem = UnityEngine.Random.Range(0, _items.Length);    // 0���� ������ ����Ʈ�� ī��Ʈ��ŭ ������ �̴´�
                    _itemList.Add(_items[randomItem]);                    // �� ������ ���Ͽ� ������ ����Ʈ�� �߰��Ѵ�  
                }
                // ui �߰� 
                _rooted = true;
            }
        }
        
    }

    void Store()
    {
       
        _itemList = new List<GameObject>();
        Building SI = Building.Store;


        if (SI == _buildingType)              // ���� �� �ǹ��� ������ type�̶� �Լ��� enum�� ������ 
        {
            int randomItemCount = UnityEngine.Random.Range(2, 9);       // ������ ī��Ʈ�� ����
            for (int i = 0; i < randomItemCount; i++)       // ������ ī��Ʈ ��ŭ �ݺ��Ѵ�
            {
                int randomItem = UnityEngine.Random.Range(0, _itemList.Count);    // 0���� ������ ����Ʈ�� ī��Ʈ��ŭ ������ �̴´�
                _itemList.Add(_items[randomItem]);                    // �� ������ ���Ͽ� ������ ����Ʈ�� �߰��Ѵ� 
            }
            // ui �߰� 
        }


    }

    void Hospital()
    {
        _itemList = new List<GameObject>();
            Building HSI = Building.Hospital;
        if (HSI == _buildingType)              // ���� �� �ǹ��� ������ type�̶� �Լ��� enum�� ������ 
        {
            int randomItemCount = UnityEngine.Random.Range(2, 9);       // ������ ī��Ʈ�� ����
            for (int i = 0; i < randomItemCount; i++)       // ������ ī��Ʈ ��ŭ �ݺ��Ѵ�
            {
                int randomItem = UnityEngine.Random.Range(0, _itemList.Count);    // 0���� ������ ����Ʈ�� ī��Ʈ��ŭ ������ �̴´�
                _itemList.Add(_items[randomItem]);                    // �� ������ ���Ͽ� ������ ����Ʈ�� �߰��Ѵ� 
            }
            // ui �߰� 
        }

    }


    void House()
    {
        _itemList = new List<GameObject>();
        Building HI = Building.House;
        if (HI == _buildingType)              // ���� �� �ǹ��� ������ type�̶� �Լ��� enum�� ������ 
        {
            int randomItemCount = UnityEngine.Random.Range(2, 9);       // ������ ī��Ʈ�� ����
            for (int i = 0; i < randomItemCount; i++)       // ������ ī��Ʈ ��ŭ �ݺ��Ѵ�
            {
                int randomItem = UnityEngine.Random.Range(0, _itemList.Count);    // 0���� ������ ����Ʈ�� ī��Ʈ��ŭ ������ �̴´�
                _itemList.Add(_items[randomItem]);                    // �� ������ ���Ͽ� ������ ����Ʈ�� �߰��Ѵ� 
            }
            // ui �߰� 
        }

    }


    void FireDepartment()
    {
        _itemList = new List<GameObject>();
        Building FaI = Building.FireDepartment;
        if (FaI == _buildingType)              // ���� �� �ǹ��� ������ type�̶� �Լ��� enum�� ������ 
        {
            int randomItemCount = UnityEngine.Random.Range(2, 9);       // ������ ī��Ʈ�� ����
            for (int i = 0; i < randomItemCount; i++)       // ������ ī��Ʈ ��ŭ �ݺ��Ѵ�
            {
                int randomItem = UnityEngine.Random.Range(0, _itemList.Count);    // 0���� ������ ����Ʈ�� ī��Ʈ��ŭ ������ �̴´�
                _itemList.Add(_items[randomItem]);                    // �� ������ ���Ͽ� ������ ����Ʈ�� �߰��Ѵ� 
            }
            // ui �߰� 
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

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
            Debug.Log(dist + " , " + gameObject.name + gameObject.tag + _buildingType + "에 접근했습니다.");
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
                Debug.Log("루팅완료");
                

            }





        }
        else if (_isContacted == true && dist >2f ) 
        {
            
             Debug.Log("멀어졌습니다");
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
            if (FI == _buildingType)              // 만약 각 건물에 설정한 type이랑 함수에 enum이 같으면 
            {
                int randomItemCount = UnityEngine.Random.Range(2, 9);       // 랜덤한 카운트를 센다
                for (int i = 0; i < randomItemCount; i++)       // 랜덤한 카운트 만큼 반복한다
                {
                    int randomItem = UnityEngine.Random.Range(0, _items.Length);    // 0에서 아이템 리스트에 카운트만큼 순서를 뽑는다
                    _itemList.Add(_items[randomItem]);                    // 그 순서를 정하여 아이템 리스트에 추가한다  
                }
                // ui 추가 
                _rooted = true;
            }
        }
        
    }

    void Store()
    {
       
        _itemList = new List<GameObject>();
        Building SI = Building.Store;


        if (SI == _buildingType)              // 만약 각 건물에 설정한 type이랑 함수에 enum이 같으면 
        {
            int randomItemCount = UnityEngine.Random.Range(2, 9);       // 랜덤한 카운트를 센다
            for (int i = 0; i < randomItemCount; i++)       // 랜덤한 카운트 만큼 반복한다
            {
                int randomItem = UnityEngine.Random.Range(0, _itemList.Count);    // 0에서 아이템 리스트에 카운트만큼 순서를 뽑는다
                _itemList.Add(_items[randomItem]);                    // 그 순서를 정하여 아이템 리스트에 추가한다 
            }
            // ui 추가 
        }


    }

    void Hospital()
    {
        _itemList = new List<GameObject>();
            Building HSI = Building.Hospital;
        if (HSI == _buildingType)              // 만약 각 건물에 설정한 type이랑 함수에 enum이 같으면 
        {
            int randomItemCount = UnityEngine.Random.Range(2, 9);       // 랜덤한 카운트를 센다
            for (int i = 0; i < randomItemCount; i++)       // 랜덤한 카운트 만큼 반복한다
            {
                int randomItem = UnityEngine.Random.Range(0, _itemList.Count);    // 0에서 아이템 리스트에 카운트만큼 순서를 뽑는다
                _itemList.Add(_items[randomItem]);                    // 그 순서를 정하여 아이템 리스트에 추가한다 
            }
            // ui 추가 
        }

    }


    void House()
    {
        _itemList = new List<GameObject>();
        Building HI = Building.House;
        if (HI == _buildingType)              // 만약 각 건물에 설정한 type이랑 함수에 enum이 같으면 
        {
            int randomItemCount = UnityEngine.Random.Range(2, 9);       // 랜덤한 카운트를 센다
            for (int i = 0; i < randomItemCount; i++)       // 랜덤한 카운트 만큼 반복한다
            {
                int randomItem = UnityEngine.Random.Range(0, _itemList.Count);    // 0에서 아이템 리스트에 카운트만큼 순서를 뽑는다
                _itemList.Add(_items[randomItem]);                    // 그 순서를 정하여 아이템 리스트에 추가한다 
            }
            // ui 추가 
        }

    }


    void FireDepartment()
    {
        _itemList = new List<GameObject>();
        Building FaI = Building.FireDepartment;
        if (FaI == _buildingType)              // 만약 각 건물에 설정한 type이랑 함수에 enum이 같으면 
        {
            int randomItemCount = UnityEngine.Random.Range(2, 9);       // 랜덤한 카운트를 센다
            for (int i = 0; i < randomItemCount; i++)       // 랜덤한 카운트 만큼 반복한다
            {
                int randomItem = UnityEngine.Random.Range(0, _itemList.Count);    // 0에서 아이템 리스트에 카운트만큼 순서를 뽑는다
                _itemList.Add(_items[randomItem]);                    // 그 순서를 정하여 아이템 리스트에 추가한다 
            }
            // ui 추가 
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

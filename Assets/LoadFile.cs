using Unity.VisualScripting;
using UnityEngine;

public class LoadFile : MonoBehaviour
{
    [SerializeField] private GameObject[] _items;
    [SerializeField] private int _spawnRadius;
    RangedWeaponList _rangedWeaponList;
    MeleeWeaponList _meleeWeaponList;
    FoodList _foodList;
    MedicineList _medicineList;


    public GameObject[] Items { get { return _items; } }
    private void Awake()
    {
        _rangedWeaponList = new RangedWeaponList();
        _meleeWeaponList = new MeleeWeaponList();
        _foodList = new FoodList();
        _medicineList = new MedicineList();
        LoadData();
    }
    void LoadData()
    {
        TextAsset rangedFile = Resources.Load("RangedWeapon") as TextAsset;
        TextAsset meleeFile = Resources.Load("MeleeWeapon") as TextAsset;
        TextAsset foodFile = Resources.Load("Food") as TextAsset;
        TextAsset medicineFile = Resources.Load("Medicine") as TextAsset;

        string rangedJson = "";
        string meleeJson = "";
        string foodJson = "";
        string medicineJson = "";

        rangedJson = rangedFile.text;
        meleeJson = meleeFile.text;
        foodJson = foodFile.text;
        medicineJson = medicineFile.text;
        if (string.IsNullOrEmpty(rangedJson) == false)
        {
            _rangedWeaponList = JsonUtility.FromJson<RangedWeaponList>(rangedJson);
            foreach(var data in _rangedWeaponList._rangedWeapons)
            {
                Debug.Log("weapon Data : "+data._name+", type : "+data._rwType);
            }
            RangedSpawn();
            Debug.Log("RangedWeapon Load가 되었습니다. ");
        }
        if (string.IsNullOrEmpty(meleeJson) == false)
        {
            _meleeWeaponList = JsonUtility.FromJson<MeleeWeaponList>(meleeJson);
            foreach (var data in _meleeWeaponList._meleeWeapons)
            {
                Debug.Log("weapon Data : " + data._name + ", type : " + data._mwType);
            }
            MeleeSpawn();
            Debug.Log("MeleeWeapon Load가 되었습니다. ");
        }
        if (string.IsNullOrEmpty(foodJson) == false)
        {
            _foodList = JsonUtility.FromJson<FoodList>(foodJson);
            foreach (var data in _foodList._foods)
            {
                Debug.Log("food Data : " + data._name + ", type : " + data._fType);
            }
            FoodSpawn();
            Debug.Log("Food Load가 되었습니다. ");
        }
        if (string.IsNullOrEmpty(medicineJson) == false)
        {
            _medicineList = JsonUtility.FromJson<MedicineList>(medicineJson);
            foreach (var data in _medicineList._medicines)
            {
                Debug.Log("medicine Data : " + data._name + ", type : " + data._mType);
            }
            MedicineSpawn();
            Debug.Log("Medicine Load가 되었습니다. ");
        }
        else
        {
            Debug.Log("파일은 있지만 내용이 없습니다. ");
        }
        LoadingMap.instance.GetComponent<LoadingMap>().MapLoad();
    }
    public GameObject SpawnItem(ItemObj obj) // 아이템 타입 검사 후 생성한 데이터를 공유
    {
        foreach (var item in _items)
        {
            ItemType itemType = item.GetComponent<ItemType>();
            if (itemType != null && obj._eType == item.GetComponent<ItemType>().Type)
            {
                // switch 
                // weapontype, foodtype, medicineType을 각각 검사해서 맞는 prefab을 로드
                GameObject temp = null;
                Debug.Log("아이템 타입 "+obj._eType +"/"+ obj._name);
                switch (obj._eType)
                {
                    case EItemType.RangedWeapon:
                        {
                            Debug.Log(((RangedWeaponData)obj)._rwType);
                            Debug.Log(item.name);
                            if(((RangedWeaponData)obj)._rwType == item.GetComponent<RangedWeapon>()._rwType)
                            {
                                temp = Instantiate(item);
                                temp.name = obj._name;
                                temp.GetComponent<ItemParent>().Init(obj);
                                temp.GetComponent<ItemType>().TypeInit(obj);
                            }
                            else
                            {
                                continue;
                            }
                        }
                        break;

                    case EItemType.MeleeWeapon:
                        {
                            //Debug.Log(((MeleeWeaponData)obj)._mwType+","+item.name);
                            Debug.Log(item.name + ", " + item.GetComponent<ItemType>().Type);
                            if (((MeleeWeaponData)obj)._mwType == item.GetComponent<MeleeWeapon>()._mwType)
                            {
                                temp = Instantiate(item);
                                temp.name = obj._name;
                                temp.GetComponent<ItemParent>().Init(obj);
                                temp.GetComponent<ItemType>().TypeInit(obj);
                            }
                            else
                            {
                                continue;
                            }
                        }
                        break;

                    case EItemType.Food:
                        {
                            Debug.Log($"food type : {((FoodData)obj)._fType}");
                            Debug.Log($"item type : {item.GetComponent<Food>()._fType}");
                            if (((FoodData)obj)._fType == item.GetComponent<Food>()._fType)
                            {
                                //Debug.Log($"switch in : {obj._name} + {item.name}");
                                temp = Instantiate(item);
                                temp.name = obj._name;
                                //Debug.Log(temp.name + temp.GetComponent<Food>()._fType + obj._name);
                                temp.GetComponent<ItemParent>().Init(obj);
                                temp.GetComponent<ItemType>().TypeInit(obj);
                            }
                            else
                            {
                                continue;
                            }
                        }
                        break;

                    case EItemType.Medicine:
                        {
                            if (((MedicineData)obj)._mType == item.GetComponent<Medicine>()._mType)
                            {
                                temp = Instantiate(item);
                                temp.name = obj._name;
                                temp.GetComponent<ItemParent>().Init(obj);
                                temp.GetComponent<ItemType>().TypeInit(obj);
                            }
                            else
                            {
                                continue;
                            }
                        }
                        break;

                    default:
                        Debug.Log($"default : {obj._name}");
                        break;
                }

                Debug.Log(item.name + temp.name);
                return temp;
            }
        }
        return null;
    }
    void RangedSpawn() // 아이템 랜덤 생성
    {
        foreach (var data in _rangedWeaponList._rangedWeapons)
        {
            Vector3 RandomPosition = Random.insideUnitSphere * _spawnRadius;
            RandomPosition.y = 0f;
            Debug.Log(data._name);
            GameObject temp = SpawnItem(data);
            if (temp == null) continue;
            temp.name = data._name;
            //아니 JSON파일을 통해서 Pistol 정보가 들어올 순 있어. 그러면 일단 경로를 살펴보자.
            //처음에 LoadData를 통해 정보가 들어오겠지.RangedWeapon에 Pistol이 있기 때문에 if 조건문에서 RangedSpawn으로 가겠지. 이 과정에서 아까 그 첫번째 로그가 찍힌거고.
            //그럼 RangedSpawn으로 가보자._rangedWeapons 데이터는 Pistol이지? 그 정보를 가지고 SpawnItem() 으로 가.
            //SpawnItem에서는 우리가 인스펙터에서 넣은 프리팹들이 있지. 그 중에서 Pistol은 없어.
            //지금 비교할 아이템은 BellPeper라는 아이템이야.이 놈은 FoodType이지.즉 Pistol이랑 타입을 비교하면 false라는 거지.
            //그러면 그 밑에 if문은 당연히 false겠지? 그럼 그 밑으로가.
            //그러면 뭐가 나와 ? return null; 이 나와. 
            //그래서 그런 거였구나? 그래서 null 레퍼런스가 뜨는거였어. 그러면 여기서 null을 리턴하는게 아니라 뭘 리턴해야할까?
            temp.transform.localScale = Vector3.one;
            temp.transform.position = RandomPosition;
        }
    }
    void MeleeSpawn() // 아이템 랜덤 생성
    {
        foreach (var data in _meleeWeaponList._meleeWeapons)
        {
            Vector3 RandomPosition = Random.insideUnitSphere * _spawnRadius;
            RandomPosition.y = 0f;
            GameObject temp = SpawnItem(data);
            if (temp == null) continue;
            temp.name = data._name;
            temp.transform.localScale = Vector3.one;
            temp.transform.position = RandomPosition;
        }
    }
    void FoodSpawn() // 아이템 랜덤 생성
    {
        foreach (var data in _foodList._foods)
        {
            Vector3 RandomPosition = Random.insideUnitSphere * _spawnRadius;
            RandomPosition.y = 0f;
            GameObject temp = SpawnItem(data);
            if (temp == null) continue;
            temp.name = data._name;
            temp.transform.localScale = Vector3.one;
            temp.transform.position = RandomPosition;
        }
    }
    void MedicineSpawn() // 아이템 랜덤 생성
    {
        foreach (var data in _medicineList._medicines)
        {
            Vector3 RandomPosition = Random.insideUnitSphere * _spawnRadius;
            RandomPosition.y = 0f;
            GameObject temp = SpawnItem(data);
            if (temp == null) continue;
            temp.name = data._name;
            temp.transform.localScale = Vector3.one;
            temp.transform.position = RandomPosition;
        }
    }

    public ItemObj SetData(GameObject obj)
    {
        ItemObj result = null;
        switch (obj.GetComponent<ItemType>().Type)
        {
            case EItemType.RangedWeapon:
                {
                    foreach(var data in _rangedWeaponList._rangedWeapons)
                    {
                        if(obj.GetComponent<RangedWeapon>()._rwType == data._rwType)
                        {
                            result = data;
                        }
                    }
                }
                break;

            case EItemType.MeleeWeapon:
                {
                    foreach (var data in _meleeWeaponList._meleeWeapons)
                    {
                        if (obj.GetComponent<MeleeWeapon>()._mwType == data._mwType)
                        {
                            result = data;
                        }
                    }
                }
                break;

            case EItemType.Food:
                {
                    foreach (var data in _foodList._foods)
                    {
                        if (obj.GetComponent<Food>()._fType == data._fType)
                        {
                            result = data;
                        }
                    }
                }
                break;

            case EItemType.Medicine:
                {
                    foreach (var data in _medicineList._medicines)
                    {
                        if (obj.GetComponent<Medicine>()._mType == data._mType)
                        {
                            result = data;
                        }
                    }
                }
                break;

            default:
                break;
        }
        return result;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, _spawnRadius);
    }
}

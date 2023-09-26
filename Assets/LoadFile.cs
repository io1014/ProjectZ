using System.IO;
using UnityEngine;

public class LoadFile : MonoBehaviour
{
    [SerializeField] private GameObject[] _items;
    [SerializeField] private int _spawnRadius;
    //ItemObjList _objList;
    RangedWeaponList _rangedWeaponList;
    FoodList _foodList;
    MedicineList _medicineList;
    

    public GameObject[] Items { get { return _items; } }
    private void Awake()
    {
        //_objList = new ItemObjList();
        _rangedWeaponList = new RangedWeaponList();
        _foodList = new FoodList();
        _medicineList = new MedicineList();
        LoadData();
    }
    void LoadData()
    {
        //Debug.Log(Application.persistentDataPath);
        TextAsset rangedFile = Resources.Load("RangedWeapon") as TextAsset;
        TextAsset foodFile = Resources.Load("Food") as TextAsset;
        TextAsset medicineFile = Resources.Load("Medicine") as TextAsset;
        //if (File.Exists(Application.persistentDataPath + "/itemdata.json"))
        string rangedJson = "";
        string foodJson = "";
        string medicineJson = "";
        //using (StreamReader inStream = new StreamReader(Application.persistentDataPath + "/itemdata.json"))
        //{
        //    json = inStream.ReadToEnd();
        //}
        rangedJson = rangedFile.text;
        foodJson = foodFile.text;
        medicineJson = medicineFile.text;
        if (string.IsNullOrEmpty(rangedJson) == false)
        {
            //_objList = JsonUtility.FromJson<ItemObjList>(json);
            _rangedWeaponList = JsonUtility.FromJson<RangedWeaponList>(rangedJson);
            RangedSpawn();
            Debug.Log("RangedWeapon Load가 되었습니다. ");
        }
        if (string.IsNullOrEmpty(foodJson) == false)
        {
            _foodList = JsonUtility.FromJson<FoodList>(foodJson);
            FoodSpawn();
            Debug.Log("Food Load가 되었습니다. ");
        }
        if (string.IsNullOrEmpty(medicineJson) == false)
        {
            _medicineList = JsonUtility.FromJson<MedicineList>(medicineJson);
            MedicineSpawn();
            Debug.Log("Medicine Load가 되었습니다. ");
        }
        else
        {
            Debug.Log("파일은 있지만 내용이 없습니다. ");
        }
        Debug.Log("Ranged File: " + rangedFile.text);
        Debug.Log("Food File: " + foodFile.text);
        Debug.Log("Medicine File: " + medicineFile.text);
        LoadingMap.instance.GetComponent<LoadingMap>().MapLoad();
    }
    public GameObject SpawnItem(ItemObj obj) // 아이템 타입 검사 후 생성한 데이터를 공유
    {
        foreach (var item in _items)
        {
            ItemType itemType = item.GetComponent<ItemType>();
            if (itemType != null && obj._eType == item.GetComponent<ItemType>().Type)
            {
                GameObject temp = Instantiate(item);
                temp.GetComponent<ItemParent>().ItemInit(obj);
                temp.GetComponent<ItemType>().Init(obj);
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
            GameObject temp = SpawnItem(data);
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
            temp.transform.localScale = Vector3.one;
            temp.transform.position = RandomPosition;
        }
    }
}

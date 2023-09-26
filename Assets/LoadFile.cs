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
        {
            string rangedjson = "";
            string foodjson = "";
            string medicinejson = "";
            //using (StreamReader inStream = new StreamReader(Application.persistentDataPath + "/itemdata.json"))
            //{
            //    json = inStream.ReadToEnd();
            //}
            rangedjson = rangedFile.text;
            if (string.IsNullOrEmpty(rangedjson) == false)
            {
                //_objList = JsonUtility.FromJson<ItemObjList>(json);
                _rangedWeaponList = JsonUtility.FromJson<RangedWeaponList>(rangedjson);
                RangedSpawn();
                Debug.Log("RangedWeapon Load�� �Ǿ����ϴ�. ");
            }
            else if(string.IsNullOrEmpty(foodjson) == false)
            {
                _foodList = JsonUtility.FromJson<FoodList>(foodjson);
                FoodSpawn();
                Debug.Log("Food Load�� �Ǿ����ϴ�. ");
            }
            else if (string.IsNullOrEmpty(medicinejson) == false)
            {
                _medicineList = JsonUtility.FromJson<MedicineList>(medicinejson);
                MedicineSpawn();
                Debug.Log("Medicine Load�� �Ǿ����ϴ�. ");
            }
            else
            {
                Debug.Log("������ ������ ������ �����ϴ�. ");
            }
        }
        LoadingMap.instance.GetComponent<LoadingMap>().MapLoad();
    }
    public GameObject SpawnItem(ItemObj obj) // ������ Ÿ�� �˻� �� ������ �����͸� ����
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
    void RangedSpawn() // ������ ���� ����
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
    void FoodSpawn() // ������ ���� ����
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
    void MedicineSpawn() // ������ ���� ����
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

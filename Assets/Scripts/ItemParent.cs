using System;
using System.IO;
using UnityEngine;
using System.Collections.Generic;

public class ItemParent : MonoBehaviour
{
    protected ItemObj _itemObj;
    protected GameObject _itemGameObject;
    [SerializeField] private GameObject[] _items;
    [SerializeField] private int _spawnRadius;

    public ItemObj ItemObj => _itemObj;
    public GameObject ItemGameObject => _itemGameObject;
    public ItemObjList _objList;
    private void Awake()
    {
        _objList = new ItemObjList();
        _objList._objs = new List<ItemObj>();

        ItemObj pistol = new ItemObj("Pistol", EItemType.Weapon, 1f, 1);
        _objList._objs.Add(pistol);

        ItemObj bread = new ItemObj("Bread", EItemType.Food, 1f, 1);
        _objList._objs.Add(bread);

        ItemObj bandage = new ItemObj("Bandage", EItemType.Medicine, 1f, 1);
        _objList._objs.Add(bandage);

        SaveData();
        LoadData();
    }
    public void SetItemObj(ItemObj item) => _itemObj = item;
    public void SetItemGameObject(GameObject itemGameObject) => _itemGameObject = itemGameObject;
    public void ItemAction()
    {
        // 인벤토리에서 Remove를 한다고 치면 해당 아이템의 정보를 인자로 받아와서 생성
        GameObject heroHand = GameObject.Find("Right");
        _itemGameObject.transform.SetParent(heroHand.transform);

        switch (_itemObj._eType)
        {
            case EItemType.Weapon:
                _itemGameObject.transform.localPosition = Vector3.zero;
                _itemGameObject.GetComponent<Pistol>().Equipped();
                break;

            case EItemType.Food:
                _itemGameObject.transform.localPosition = Vector3.zero;
                _itemGameObject.GetComponent<Bread>().Eating();
                break;

            case EItemType.Medicine:
                _itemGameObject.transform.localPosition = Vector3.zero;
                _itemGameObject.GetComponent<Bandage>().FirstAid();
                break;
            default:
                break;
        }
    }
    void SaveData()
    {
        string json = JsonUtility.ToJson(_objList);
        string path = Application.persistentDataPath + "/itemdata.json";
        using (StreamWriter outStream = File.CreateText(path))
        {
            outStream.Write(json);
        }
        Debug.Log(json);
    }
    void LoadData()
    {
        if (File.Exists(Application.persistentDataPath + "/itemdata.json"))
        {
            string json = "";
            using (StreamReader inStream = new StreamReader(Application.persistentDataPath + "/itemdata.json"))
            {
                json = inStream.ReadToEnd();
            }
            if (string.IsNullOrEmpty(json) == false)
            {
                _objList = JsonUtility.FromJson<ItemObjList>(json);
                SpawnItems();
                Debug.Log("Load가 되었습니다. ");
            }
            else
            {
                Debug.Log("파일은 있지만 내용이 없습니다. ");
            }
        }
        else
        {
            Debug.Log("파일이 없습니다. ");
        }
    }
    void SpawnItems()
    {
        foreach(var data in _objList._objs)
        {
            foreach(var item in _items)
            {
                ItemType itemType = item.GetComponent<ItemType>();
                if(itemType != null && data._eType == item.GetComponent<ItemType>().Type)
                {
                    Vector3 RandomPosition = UnityEngine.Random.insideUnitSphere * _spawnRadius;
                    RandomPosition.y = 0f;

                    GameObject temp = Instantiate(item, RandomPosition, Quaternion.identity);
                    temp.GetComponent<ItemType>().Init(data);
                    temp.transform.position = RandomPosition;
                    break;
                }
            }
        }
    }
}

[Serializable]
public class ItemObjList
{
    public List<ItemObj> _objs;
}

[Serializable]
public class ItemObj
{
    //public Sprite _sprite;
    public string _name;
    public EItemType _eType;
    public float _scale;
    public int _count;
    public ItemObj(/*Sprite spr,*/ string name, EItemType etype, float scale, int count)
    {
        //_sprite = spr;
        _name = name;
        _eType = etype;
        _scale = scale;
        _count = count;
    }
}
//public class WeaponItem : ItemObj
//{
//    public WeaponItem(/*Sprite spr,*/ string name, EItemType etype, float scale, int count)
//        : base(name, EItemType.Weapon, 1f, 1) { }
//}

public enum EItemType
{
    // 무기
    Weapon,
    // 음식
    Food,
    // 의약품
    Medicine,
}
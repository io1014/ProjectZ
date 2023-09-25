using System.IO;
using UnityEngine;

public class LoadFile : MonoBehaviour
{
    [SerializeField] private GameObject[] _items;
    [SerializeField] private int _spawnRadius;
    ItemObjList _objList;
    public GameObject[] Items { get { return _items; } }
    private void Awake()
    {
        _objList = new ItemObjList();
        LoadData();
    }
    void LoadData()
    {
        //Debug.Log(Application.persistentDataPath);
        TextAsset ta = Resources.Load("itemdata") as TextAsset;
        //if (File.Exists(Application.persistentDataPath + "/itemdata.json"))
        {
            string json = "";
            //using (StreamReader inStream = new StreamReader(Application.persistentDataPath + "/itemdata.json"))
            //{
            //    json = inStream.ReadToEnd();
            //}
            json = ta.text;
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
        //else
        //{
        //    Debug.Log("파일이 없습니다. ");
        //}

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
                temp.GetComponent<ItemType>().Init(obj);
                return temp;
            }
        }
        return null;
    }
    void SpawnItems() // 아이템 랜덤 생성
    {
        foreach (var data in _objList._objs)
        {
            Vector3 RandomPosition = Random.insideUnitSphere * _spawnRadius;
            RandomPosition.y = 0f;
            GameObject temp = SpawnItem(data);
            temp.transform.localScale = Vector3.one;
            temp.transform.position = RandomPosition;
        }
    }
}

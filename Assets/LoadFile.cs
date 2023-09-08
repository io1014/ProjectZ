using System.IO;
using UnityEngine;

public class LoadFile : MonoBehaviour
{
    [SerializeField] private GameObject[] _items;
    [SerializeField] private int _spawnRadius;
    public ItemObjList _objList;
    private void Awake()
    {
        _objList = new ItemObjList();
        LoadData();
    }
    void LoadData()
    {
        //Debug.Log(Application.persistentDataPath);
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
    public GameObject SpawnItem(ItemObj obj)
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
    void SpawnItems()
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

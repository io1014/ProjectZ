using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadWrite : MonoBehaviour
{
    [SerializeField] string _name;
    [SerializeField] EItemType _type;
    [SerializeField] float _scale;
    [SerializeField] int _count;

    ItemObjList _objList;
    private void Start()
    {
        _objList = new ItemObjList();
        _objList._objs = new List<ItemObj>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            SaveData();
        }
    }
    void SaveData()
    {
        // 새로운 씬을 만들고 그 안에서 아이템들을 json 파일로 저장
        ItemObj itemData = new ItemObj(_name, _type, _scale, _count);
        _objList._objs.Add(itemData);
        string json = JsonUtility.ToJson(_objList);
        string path = Application.persistentDataPath + "/itemdata.json";
        using (StreamWriter outStream = File.CreateText(path))
        {
            outStream.Write(json);
        }
        Debug.Log(json);
    }
}

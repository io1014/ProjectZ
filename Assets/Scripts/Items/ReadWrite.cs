using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadWrite : MonoBehaviour
{
    [SerializeField] string _name;
    [SerializeField] EItemType _type;
    [SerializeField] float _weight;
    [SerializeField] float _scale;
    [SerializeField] int _count;

    //ItemObjList _objList;
    RangedWeaponList _rangedWeaponList;
    FoodList _foodList;
    MedicineList _medicineList;
    private void Start()
    {
        //_objList = new ItemObjList();
        //_objList._objs = new List<ItemObj>();
        _rangedWeaponList = new RangedWeaponList();
        _rangedWeaponList._rangedWeapons = new List<RangedWeaponData>();

        _foodList = new FoodList();
        _foodList._foods = new List<FoodData>();

        _medicineList = new MedicineList();
        _medicineList._medicines = new List<MedicineData>();
    }
    private void Update()
    {
        //if(Input.GetKeyDown(KeyCode.S))
        //{
        //    SaveData();
        //}
    }
    //void RangedWeaponSaveData()
    //{
    //    // 새로운 씬을 만들고 그 안에서 아이템들을 json 파일로 저장
    //    RangedWeaponData itemData = new List<RangedWeaponData>(_name, _type, _weight, _scale, _count);
    //    _rangedWeaponList._rangedWeapons.Add(itemData);
    //    string json = JsonUtility.ToJson(_rangedWeaponList);
    //    string path = Application.persistentDataPath + "/itemdata.json";
    //    using (StreamWriter outStream = File.CreateText(path))
    //    {
    //        outStream.Write(json);
    //    }
    //    Debug.Log(json);
    //}
}

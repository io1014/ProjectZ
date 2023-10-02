using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadWrite : MonoBehaviour
{
    [Header("Common Properties")]
    [SerializeField] string _name;
    [SerializeField] EItemType _type;
    [SerializeField] float _weight;
    [SerializeField] float _scale;
    [SerializeField] int _count;

    [Header("RangedWeapon")]
    [SerializeField] int _attackDamage;
    [SerializeField] float _range;
    [SerializeField] float _reloadTime;
    [SerializeField] float _bulletSpeed;
    [SerializeField] int _magAmmo;
    [SerializeField] RangedWeaponType _rwType;

    [Header("MeleeWeapon")]
    [SerializeField] int _swingDamage;
    [SerializeField] int _swingSpeed;
    [SerializeField] float _duration;
    [SerializeField] MeleeWeaponType _mwType;

    [Header("Food|Medicine")]
    [SerializeField] float _increaseHP;
    [SerializeField] float _increaseFull;
    [SerializeField] FoodType _fType;
    [SerializeField] MedicineType _mType;

    //ItemObjList _objList;
    RangedWeaponList _rangedWeaponList;
    MeleeWeaponList _meleeWeaponList;
    FoodList _foodList;
    MedicineList _medicineList;
    private void Start()
    {
        //_objList = new ItemObjList();
        //_objList._objs = new List<ItemObj>();
        _rangedWeaponList = new RangedWeaponList();
        _rangedWeaponList._rangedWeapons = new List<RangedWeaponData>();

        _meleeWeaponList = new MeleeWeaponList();
        _meleeWeaponList._meleeWeapons = new List<MeleeWeaponData>();

        _foodList = new FoodList();
        _foodList._foods = new List<FoodData>();

        _medicineList = new MedicineList();
        _medicineList._medicines = new List<MedicineData>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            switch ( _type )
            {
                case EItemType.RangedWeapon:
                    RangedWeaponSaveData(); break;

                case EItemType.MeleeWeapon:
                    MeleeWeaponSaveData(); break;

                case EItemType.Food:
                    FoodSaveData(); break;

                case EItemType.Medicine:
                    MedicineSaveData(); break;

                default: break;
            }
        }
    }
    void RangedWeaponSaveData()
    {
        // 새로운 씬을 만들고 그 안에서 아이템들을 json 파일로 저장
        RangedWeaponData itemData = new RangedWeaponData(_name, _type, _weight, _scale, _count, 
            _attackDamage, _range, _reloadTime, _bulletSpeed, _magAmmo, _rwType);
        _rangedWeaponList._rangedWeapons.Add(itemData);
        string json = JsonUtility.ToJson(_rangedWeaponList);
        string path = Application.persistentDataPath + "/RangedWeapon.json";
        using (StreamWriter outStream = File.CreateText(path))
        {
            outStream.Write(json);
        }
        Debug.Log(json);
    }
    void MeleeWeaponSaveData()
    {
        // 새로운 씬을 만들고 그 안에서 아이템들을 json 파일로 저장
        MeleeWeaponData itemData = new MeleeWeaponData(_name, _type, _weight, _scale, _count,
            _swingDamage, _swingSpeed, _duration, _mwType);
        _meleeWeaponList._meleeWeapons.Add(itemData);
        string json = JsonUtility.ToJson(_meleeWeaponList);
        string path = Application.persistentDataPath + "/MeleeWeapon.json";
        using (StreamWriter outStream = File.CreateText(path))
        {
            outStream.Write(json);
        }
        Debug.Log(json);
    }
    void FoodSaveData()
    {
        // 새로운 씬을 만들고 그 안에서 아이템들을 json 파일로 저장
        FoodData itemData = new FoodData(_name, _type, _weight, _scale, _count, _increaseHP, _increaseFull, _fType);
        _foodList._foods.Add(itemData);
        string json = JsonUtility.ToJson(_foodList);
        string path = Application.persistentDataPath + "/Food.json";
        using (StreamWriter outStream = File.CreateText(path))
        {
            outStream.Write(json);
        }
        Debug.Log(json);
    }
    void MedicineSaveData()
    {
        // 새로운 씬을 만들고 그 안에서 아이템들을 json 파일로 저장
        MedicineData itemData = new MedicineData(_name, _type, _weight, _scale, _count, _increaseHP, _mType);
        _medicineList._medicines.Add(itemData);
        string json = JsonUtility.ToJson(_medicineList);
        string path = Application.persistentDataPath + "/Medicine.json";
        using (StreamWriter outStream = File.CreateText(path))
        {
            outStream.Write(json);
        }
        Debug.Log(json);
    }
}

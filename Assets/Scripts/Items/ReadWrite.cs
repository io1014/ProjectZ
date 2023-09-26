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

    [Header("Food|Medicine")]
    [SerializeField] float _increaseHP;
    [SerializeField] float _increaseFull;

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
        if (Input.GetKeyDown(KeyCode.S))
        {
            switch ( _type )
            {
                case EItemType.Weapon:
                    RangedWeaponSaveData(); break;

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
        // ���ο� ���� ����� �� �ȿ��� �����۵��� json ���Ϸ� ����
        RangedWeaponData itemData = new RangedWeaponData(_name, _type, _weight, _scale, _count, 
            _attackDamage, _range, _reloadTime, _bulletSpeed, _magAmmo);
        _rangedWeaponList._rangedWeapons.Add(itemData);
        string json = JsonUtility.ToJson(_rangedWeaponList);
        string path = Application.persistentDataPath + "/RangedWeapon.json";
        using (StreamWriter outStream = File.CreateText(path))
        {
            outStream.Write(json);
        }
        Debug.Log(json);
    }
    void FoodSaveData()
    {
        // ���ο� ���� ����� �� �ȿ��� �����۵��� json ���Ϸ� ����
        FoodData itemData = new FoodData(_name, _type, _weight, _scale, _count, _increaseHP, _increaseFull);
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
        // ���ο� ���� ����� �� �ȿ��� �����۵��� json ���Ϸ� ����
        MedicineData itemData = new MedicineData(_name, _type, _weight, _scale, _count, _increaseHP);
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

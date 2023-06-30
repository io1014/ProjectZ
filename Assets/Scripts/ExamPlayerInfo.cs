using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamPlayerInfo : MonoBehaviour
{
    ItemObj _itemObj;
    [SerializeField] GameObject _pistolPrefab;
    GameObject _pistol;
    private void Start()
    {
        _itemObj = new ItemObj(/*null,*/ "Pistol", EItemType.Pistol);
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && _pistol == null)
        {
            _pistol = Instantiate(_pistolPrefab);
            Pistol pistolComponont = _pistol.GetComponent<Pistol>();
            if (pistolComponont != null)
            {
                _itemObj.Stack(pistolComponont);
                _itemObj.Equip();
            }
        }
    }
}

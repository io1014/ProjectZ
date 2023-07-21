using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemSlotDestroy : MonoBehaviour
{
    [SerializeField] GameObject _destroyItem;

    public void itemDestroy()
    {
        DestroyObject(_destroyItem);
    }
}

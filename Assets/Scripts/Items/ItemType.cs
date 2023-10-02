using UnityEngine;

public class ItemType : ItemParent
{
    [SerializeField] EItemType type;
    public EItemType Type { get { return type; } }

    public void TypeInit(ItemObj data)
    {
        _itemObj = data;
        transform.localScale = Vector3.one * _itemObj._scale;
        data._count = _itemObj._count;
    }
}

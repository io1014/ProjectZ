using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] Image _img;
    public ItemObj _itemdata;
    IItemHandler _handler;

    public void Init(ItemObj data, Sprite spr, IItemHandler handler)
    {
        _handler = handler;
        _itemdata = data;
        _img.sprite = spr;
    }
    public void ONButton()
    {
        // 플레이어 인벤쪽에 _itemdata전달
        _handler.MoveItem(gameObject);
        Destroy(gameObject);
    }
}

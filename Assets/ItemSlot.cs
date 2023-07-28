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

    public void OnPlayerInvenButton()
    {
        GameObject hero = GameObject.Find("Player");
        LoadFile temp = GameObject.Find("LoadFile").GetComponent<LoadFile>();
        GameObject tp = temp.SpawnItem(_itemdata);
        tp.transform.position = hero.transform.position + hero.transform.forward * 0.5f;

        ItemParent ip = new ItemParent();
        ip.SetItemGameObject(tp);
        ip.ItemAction(tp.GetComponent<ItemType>().Type);
        // 일단 월드에 게임오브젝트를 만든다.
        // 만들어지는 위치 캐릭터 앞 // 히어로정보
        // 만들 정보  <- itemParent가 제네릭 이어야 한다.
        // 그 다음에 itemAction을 실행한다.

        Destroy(gameObject);
    }
}

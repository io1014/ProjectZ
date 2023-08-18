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


        GameObject hero = GameObject.Find("Player");
        LoadFile temp = GameObject.Find("LoadFile").GetComponent<LoadFile>();
        GameObject tp = temp.SpawnItem(_itemdata);
        Debug.Log(tp.name + "OnBtn");

        GameObject heroHand = GameObject.Find("Right");
        tp.transform.SetParent(heroHand.transform);
        tp.transform.localPosition = Vector3.zero;
        tp.transform.localRotation = Quaternion.identity;

        ItemParent ip = new ItemParent();
        ip.SetItemGameObject(tp);
        ip.ItemAction(tp.GetComponent<ItemType>().Type);

        _handler.MoveItem(gameObject);
        Destroy(gameObject);
    }

      

   

    public void OnPlayerInvenButton()
    {
        GenericSingleton<PlayerItemInventory>._instance.GetComponent<PlayerItemInventory>().RemoveInventoryItem(gameObject);
        Destroy(gameObject);
    }

    public void RemoveItem()
    {
        // 일단 월드에 게임오브젝트를 만든다.
        // 만들어지는 위치 캐릭터 앞 // 히어로정보
        // 만들 정보  <- itemParent가 제네릭 이어야 한다.
        // 그 다음에 itemAction을 실행한다.

        GameObject hero = GameObject.Find("Player");
        LoadFile temp = GameObject.Find("LoadFile").GetComponent<LoadFile>();
        GameObject tp = temp.SpawnItem(_itemdata);
        Debug.Log(tp.name + "OnPlayerBtn");

        tp.transform.position = hero.transform.position + hero.transform.forward * 0.5f;

        GenericSingleton<PlayerItemInventory>._instance.GetComponent<PlayerItemInventory>().RemoveInventoryItem(gameObject);
        Destroy(gameObject);
    }

}

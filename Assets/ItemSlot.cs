using UnityEngine;
using UnityEngine.UI;
public enum ESlotType
{
    myInven,
    houseInven,
    CarryInven,
}
public class ItemSlot : MonoBehaviour
{
    [SerializeField] Image _img;
    public ItemObj _itemdata;
    IItemHandler _handler;
    ESlotType eType;

    public void Init(ItemObj data, Sprite spr, IItemHandler handler, ESlotType type )
    {
        _handler = handler;
        _itemdata = data;
        _img.sprite = spr;
        eType = type;
    }


    public void ONButton()
    {
        bool text = GenericSingleton<PlayerItemInventory>._instance.GetComponent<PlayerItemInventory>().GetText();
        if(eType == ESlotType.myInven && text == false)
        {
            ItemObj itemData = _itemdata;
            if(itemData._eType == EItemType.Weapon)
            {
            GameObject hero = GameObject.Find("Hero");
            LoadFile temp = GameObject.Find("LoadFile").GetComponent<LoadFile>();
            GameObject tp = temp.SpawnItem(itemData);
            Debug.Log(tp.name + "OnBtn");

            GameObject heroHand = GameObject.Find("Rweaponholder");
            tp.transform.SetParent(heroHand.transform);
            tp.transform.localScale = Vector3.one;
            tp.transform.localPosition = Vector3.zero;
            tp.transform.localRotation = Quaternion.identity;

            ItemParent ip = new ItemParent();
            ip.SetItemGameObject(tp);
            ip.UseItem(tp.GetComponent<ItemType>().Type);

            _handler.MoveItem(gameObject);
            Destroy(gameObject);
            }
            else
            {
                ItemParent ip = new ItemParent();
                ip.UseItem(itemData._eType);

                _handler.MoveItem(gameObject);
                Destroy(gameObject);
            }
        }
        else if(eType == ESlotType.myInven && text == true)
        {
            _handler.MoveItem(gameObject);
            Destroy(gameObject);
        }
        else if(eType == ESlotType.houseInven)
        {
            _handler.MoveItem(gameObject);
            Destroy(gameObject);
        }
        else if(eType == ESlotType.CarryInven)
        {
            // 캐리 인벤인 경우
            // 슬롯을 클릭했을 때 생성되지않고, 마이 인벤으로 옮기기만 해야함
            _handler.MoveItem(gameObject);
            Destroy(gameObject);
        }
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

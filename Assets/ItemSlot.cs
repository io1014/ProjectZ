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
        Debug.Log("아이템 버튼 클릭");
        PlayerItemInventory myInven = GenericSingleton<PlayerItemInventory>._instance.GetComponent<PlayerItemInventory>();

        bool text = myInven.GetText();
        int slotCount = myInven.GetSlotCount();
        Sprite[] spr = myInven.GetSprites();
        if (eType == ESlotType.myInven && text == false)
        {
            bool checkSpr = false;
            for (int i = 0; i < 12; i++)
            {
                Debug.Log($"for문이 {i}번째 돌아갑니다.");
                if (_img.sprite == spr[i])
                {
                    Debug.Log($"실제 아이템의 스프라이트 : {_img.sprite} , 비교할 스프라이트 : {spr[i]}");
                    checkSpr = true;
                    Debug.Log($"if문에 들어간 bool 값은 : {checkSpr}");
                    break;
                }
                else
                {
                    checkSpr = false;
                    Debug.Log($"else에 들어간 bool 값은 : {checkSpr}");
                }
            }
            Debug.Log($"현재 bool 값은 : {checkSpr}");
            if (checkSpr == true)
            {
                Debug.Log("CheckSprite !");
                if (slotCount >= 1) return;
                MakeItem();
                slotCount++;
                Debug.Log("갱신된 슬롯 카운트 : " + slotCount);
                myInven.SetSlotCount(slotCount);
            }
            else
            {
                Debug.Log("No CheckSprite !");
                MakeItem();
                //Debug.Log($"MakeItem !");
            }
        }
        else if (eType == ESlotType.myInven && text == true)
        {
            _handler.MoveItem(gameObject);
            Destroy(gameObject);
        }
        else if (eType == ESlotType.houseInven)
        {
            _handler.MoveItem(gameObject);
            Destroy(gameObject);
        }
        else if (eType == ESlotType.CarryInven)
        {
            _handler.MoveItem(gameObject);
            Destroy(gameObject);
        }
    }

    void MakeItem()
    {
        GameObject hero = GameObject.Find("Hero");
        LoadFile temp = GameObject.Find("LoadFile").GetComponent<LoadFile>();
        GameObject tp = temp.SpawnItem(_itemdata);
        Debug.Log(tp.name + "OnBtn");

        GameObject heroHand = GameObject.Find("Rweaponholder");
        tp.transform.SetParent(heroHand.transform);
        tp.transform.localPosition = Vector3.zero;
        tp.transform.localRotation = Quaternion.identity;

        ItemParent ip = tp.GetComponent<ItemParent>();
        ip.SetItemGameObject(tp);
        ip.UseItem(tp.GetComponent<ItemType>().Type);

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

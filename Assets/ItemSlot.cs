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
        Debug.Log("������ ��ư Ŭ��");
        PlayerItemInventory myInven = GenericSingleton<PlayerItemInventory>._instance.GetComponent<PlayerItemInventory>();

        bool text = myInven.GetText();
        //int slotCount = myInven.GetSlotCount();
        int rangedCount = myInven._rangedSlotCount;
        int meleeCount = myInven._meleeSlotCount;
        Sprite[] spr = myInven.GetSprites();
        if (eType == ESlotType.myInven && text == false) // ���� �κ��� ��
        {
            bool checkSpr = false;
            Sprite sprNumber = null;
            for (int i = 0; i < 12; i++) // �������� ��
            {
                Debug.Log($"for���� {i}��° ���ư��ϴ�.");
                if (_img.sprite == spr[i]) // �ش� �����۰� �ν������� sprite�� ���� ��
                {
                    Debug.Log($"���� �������� ��������Ʈ : {_img.sprite} , ���� ��������Ʈ : {spr[i]}");
                    checkSpr = true;
                    sprNumber = spr[i];
                    Debug.Log($"if���� �� bool ���� : {checkSpr}");
                    break;
                }
                else
                {
                    checkSpr = false;
                    Debug.Log($"else�� �� bool ���� : {checkSpr}");
                }
            }
            Debug.Log($"���� bool ���� : {checkSpr}");
            if (checkSpr == true) // �ش� �����۰� �ν������� sprite�� ���� �� 2
            {
                if(/*(int)sprNumber <= 2*/true) // �� �������� ranged�� ��
                {
                    Debug.Log("RangedCheckSprite !");
                    if (rangedCount >= 1) return;
                    rangedCount++;
                    //myInven.SetSlotCount(slotCount);
                    Debug.Log("�߰��� ���� ī��Ʈ : " + rangedCount);
                    MakeItem();
                }
                else if(true) // �� �������� melee�� ��
                {
                    Debug.Log("MeleeCheckSprite !");
                    if (meleeCount >= 1) return;
                    meleeCount++;
                    //myInven.SetSlotCount(slotCount);
                    Debug.Log("�߰��� ���� ī��Ʈ : " + meleeCount);
                    MakeItem();
                }
            }
            else
            {
                Debug.Log("No CheckSprite !");
                MakeItem();
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
        tp.transform.localScale = Vector3.one;
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
        // �ϴ� ���忡 ���ӿ�����Ʈ�� �����.
        // ��������� ��ġ ĳ���� �� // ���������
        // ���� ����  <- itemParent�� ���׸� �̾�� �Ѵ�.
        // �� ������ itemAction�� �����Ѵ�.

        GameObject hero = GameObject.Find("Player");
        LoadFile temp = GameObject.Find("LoadFile").GetComponent<LoadFile>();
        GameObject tp = temp.SpawnItem(_itemdata);
        Debug.Log(tp.name + "OnPlayerBtn");

        tp.transform.position = hero.transform.position + hero.transform.forward * 0.5f;

        GenericSingleton<PlayerItemInventory>._instance.GetComponent<PlayerItemInventory>().RemoveInventoryItem(gameObject);
        Destroy(gameObject);
    }

}

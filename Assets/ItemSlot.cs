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

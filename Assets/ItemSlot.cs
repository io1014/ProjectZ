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
        // �÷��̾� �κ��ʿ� _itemdata����
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
        // �ϴ� ���忡 ���ӿ�����Ʈ�� �����.
        // ��������� ��ġ ĳ���� �� // ���������
        // ���� ����  <- itemParent�� ���׸� �̾�� �Ѵ�.
        // �� ������ itemAction�� �����Ѵ�.

        Destroy(gameObject);
    }
}

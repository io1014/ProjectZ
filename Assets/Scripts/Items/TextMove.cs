using UnityEngine;
using UnityEngine.UI;

public class TextMove : GenericSingleton<TextMove>
{
    [SerializeField] GameObject _txt;
    private void Update()
    {
        transform.position += Vector3.up;
    }
    public void DestroyEvent()
    {
        Destroy(gameObject);
    }
    public void CreateText(Transform applyPoint, float ApplyTxt)
    {
        gameObject.SetActive(true);
        GameObject text = Instantiate(_txt, applyPoint);
        _txt.GetComponent<Text>().text = $"���� �Ծ����ϴ�. ü�� {ApplyTxt.ToString()} ��(��) ȸ���˴ϴ�.";
        gameObject.SetActive(false);
    }
}

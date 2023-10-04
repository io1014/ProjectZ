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
        _txt.GetComponent<Text>().text = $"빵을 먹었습니다. 체력 {ApplyTxt.ToString()} 이(가) 회복됩니다.";
        gameObject.SetActive(false);
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextUsing : ItemParent
{
    [SerializeField] float _moveSpeed;
    [SerializeField] float _alphaSpeed;
    [SerializeField] float _destroyTime;
    TextMesh _text;
    Color _alpha;
    float _eatFood;
    string _eatText;
    private void Start()
    {
        _text = GetComponent<TextMesh>();
        Debug.Log($"받은 데이터 량은 {_eatFood}");
        Debug.Log(_text.name);
        _text.text = "";
        Debug.Log(_text.text);
        _alpha = _text.color;
        Invoke("DestroyObj", _destroyTime);
    }
    void Update()
    {
        transform.Translate(new Vector3(0, _moveSpeed * Time.deltaTime, 0));
        _alpha.a = Mathf.Lerp(_alpha.a, 0, Time.deltaTime * _alphaSpeed);
        _text.color = _alpha;
    }
    public void SetFood(float eatFood)
    { 
        _eatFood = eatFood;
    }
    public void SetText(string text)
    {
        _eatText = text;
    }
    void DestroyObj()
    {
        Destroy(gameObject);
    }
}

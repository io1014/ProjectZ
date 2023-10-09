using TMPro;
using UnityEngine;

public class TextUsing : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    [SerializeField] float _alphaSpeed;
    [SerializeField] float _destroyTime;
    TextMeshPro _text;
    Color _alpha;
    public float _eatFood{ get; set; }
    private void Start()
    {
        _text = GetComponent<TextMeshPro>();
        _text.text = _eatFood.ToString();
        _alpha = _text.color;
        Invoke("DestroyObj", _destroyTime);
    }
    void Update()
    {
        transform.Translate(new Vector3(0, _moveSpeed * Time.deltaTime, 0));
        _alpha.a = Mathf.Lerp(_alpha.a, 0, Time.deltaTime * _alphaSpeed);
        _text.color = _alpha;
    }
    void DestroyObj()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using UnityEngine;

public class TextMove : GenericSingleton<TextMove>
{
    [SerializeField] Transform _camTarget;
    [SerializeField] Transform _txtTrans;

    bool _isTextOn = false;
    float _textOnInterval = 1.0f;

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            _txtTrans.gameObject.SetActive(true);
            StartTextOnCoroutine();
        }
        if(Input.GetMouseButtonDown(1))
        {
            _txtTrans.gameObject.SetActive(false);
            _txtTrans.position = gameObject.transform.position;
            StopTextOnCoroutine();
        }
    }
    private void StartTextOnCoroutine()
    {
        if (!_isTextOn)
        {
            StartCoroutine(TextOnCoroutine());
        }
    }
    private IEnumerator TextOnCoroutine()
    {
        _isTextOn = true; // TextOn ���� �� �÷��� ����
        while (_txtTrans.gameObject.activeSelf)
        {
            TextOn(); // TextOn �޼��� ȣ��
            yield return new WaitForSeconds(_textOnInterval); // ���� ���� ���
        }
        _isTextOn = false; // TextOn ���� ���� �÷��� ����
    }
    private void StopTextOnCoroutine()
    {
        StopAllCoroutines();
        _isTextOn = false; // TextOn ���� ���� �÷��� ����
    }
    void TextOn()
    {
        _txtTrans.transform.position += Vector3.up * Time.deltaTime;
        _txtTrans.LookAt(_camTarget);
    }
}

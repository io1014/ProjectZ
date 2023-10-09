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
        _isTextOn = true; // TextOn 실행 중 플래그 설정
        while (_txtTrans.gameObject.activeSelf)
        {
            TextOn(); // TextOn 메서드 호출
            yield return new WaitForSeconds(_textOnInterval); // 일정 간격 대기
        }
        _isTextOn = false; // TextOn 실행 종료 플래그 설정
    }
    private void StopTextOnCoroutine()
    {
        StopAllCoroutines();
        _isTextOn = false; // TextOn 실행 종료 플래그 설정
    }
    void TextOn()
    {
        _txtTrans.transform.position += Vector3.up * Time.deltaTime;
        _txtTrans.LookAt(_camTarget);
    }
}

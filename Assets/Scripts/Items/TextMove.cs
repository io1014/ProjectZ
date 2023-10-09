using System.Collections;
using UnityEngine;

public class TextMove : GenericSingleton<TextMove>
{
    [SerializeField] Transform _camTarget;
    [SerializeField] Transform _txtTrans;

    //private void Update()
    //{
    //    TextOn();
    //}
    //void TextOn()
    //{
    //    _txtTrans.transform.position += Vector3.up * Time.deltaTime;
    //    _txtTrans.LookAt(_camTarget);
    //    Invoke("DestroyText", 1.0f);
    //}
    //void DestroyText()
    //{
    //    Destroy(_txtTrans.gameObject);
    //}
    private void Start()
    {
        StartCoroutine(MoveTextUp());
    }
    public IEnumerator MoveTextUp()
    {
        float elapsedTime = 0;
        Vector3 initialPos = _txtTrans.position;
        Vector3 targetPos = initialPos + Vector3.up;

        while(elapsedTime < 1.0f)
        {
            _txtTrans.position = Vector3.Lerp(initialPos, targetPos, elapsedTime / 1.0f);
            _txtTrans.LookAt(_camTarget);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        _txtTrans.gameObject.SetActive(false);
    }
}

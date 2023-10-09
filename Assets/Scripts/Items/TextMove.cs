using System.Collections;
using UnityEngine;

public class TextMove : GenericSingleton<TextMove>
{
    [SerializeField] Transform _camTarget;
    [SerializeField] Transform _txtTrans;
    private void Start()
    {
        StartCoroutine(MoveTextUp());
    }
    private void Update()
    {
        
    }
    public IEnumerator MoveTextUp()
    {
        Debug.Log("코루틴 실행");
        float elapsedTime = 0;
        Vector3 initialPos = _txtTrans.position;
        Vector3 targetPos = initialPos + Vector3.up;
        _txtTrans.gameObject.SetActive(true);

        while (elapsedTime < 1.0f)
        {
            Debug.Log("코루틴 While문 실행");
            _txtTrans.position = Vector3.Lerp(initialPos, targetPos, elapsedTime / 1.0f);
            Debug.Log("Lerp 실행");
            _txtTrans.rotation = _camTarget.transform.rotation;
            Debug.Log("Rotation 값 할당");
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        _txtTrans.gameObject.SetActive(false);
        elapsedTime = 0;
    }
    public void Activate()
    {
        _txtTrans.gameObject.SetActive(true);
    }
}

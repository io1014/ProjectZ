using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextUI : MonoBehaviour
{
    [SerializeField] Transform _text;
    [SerializeField] GameObject _heroTras;
    void Update()
    {
        _text.transform.position = _heroTras.transform.position;
    }
    //IEnumerator TextOn()
    //{
    //    _text.gameObject.SetActive(true);
    //    _text.transform.position = Vector3.up * Time.deltaTime;
    //    yield return WaitForSeconds();
    //}
}

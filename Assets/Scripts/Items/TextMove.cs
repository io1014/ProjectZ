using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextMove : GenericSingleton<TextMove>
{
    [SerializeField] Text _txt;
    private void Start()
    {
        //StartCoroutine(FadeText());
    }
    private void Update()
    {
        transform.position += Vector3.up;
    }
    //public void createtext(transform applypoint, float applytext)
    //{
    //    _txt.gameobject.setactive(true);
    //    gameobject text = instantiate(_txt, applypoint);
    //    _txt.getcomponent<text>().text = $"빵을 먹었습니다. 체력 {applytext} 이(가) 회복됩니다.";
    //    invoke("textoff", 1.7f);
    //}
    public IEnumerator FadeText()
    {
        yield return null;
        _txt.color = new Color(_txt.color.r, _txt.color.g, _txt.color.b, 0f);
        //while (_txt.color.a < 1.0f)
        //{
        //    _txt.color = new Color(_txt.color.r, _txt.color.g, _txt.color.b, _txt.color.a + (Time.deltaTime / 2.0f));
        //}
    }
}

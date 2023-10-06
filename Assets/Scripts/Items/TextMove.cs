using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextMove : GenericSingleton<TextMove>
{
    [SerializeField] Text _txt;

    private void Start()
    {
        GameObject temp = GameObject.Find("TextPoint");
    }
    private void Update()
    {
        //transform.position += Vector3.up;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class typeingEffect : MonoBehaviour
{

    public Text tx;
    private string m_text = "�̷��� ��� �� ����� ���� �� ��ħ. ������ ��� ���� ���� �־���." +
        " \r\n\r\n\r\n������ �� �� ���� ���̷��� ������ ������� ��ġ���̷� ���ذ��� " +
        "�Ϻ��� ������� ����� ���Ͽ�\r\n������ ��� ����ü�� �����ϱ� �����ߴ�." +
        "\r\n\r\n\r\n������ ��� �ý����� ������Ȱ� Ȧ�� ���� ����� ��� ���� ���� �����ڵ��� " +
        "ã�� ���� ������ �����ؾ� �Ѵ�.\r\n\r\n \r\n����� ������ ������ ���Ƴ��� �� �� �ƴ϶� " +
        "�����, ����, �Ƿ� �͵� �ο� �̰ܳ��� �Ѵ�. \r\n\r\n\r\n������ ã�ƿ��� �㿡�� ����� " +
        "�þߴ� ���� ��Ӱ� �Ǹ� ����� �����Ͽ� ������ ���� �� �ۿ� ����.\r\n\r\n\r\n���ô� Ȳ��ȭ " +
        "�Ǿ����� ������ �ǹ� �������� ��, Į�� ���� ����� �ķ�, �� �� ������ �ʿ��� ���ǵ��� " +
        "ȹ���� �� �ִ�. \r\n\r\n\r\n������ �ǹ��� �����Ͽ� ������ �ʿ��� �������� ȸ���ϰ�, " +
        "������� ���� ���ϰų� �����ľ� �Ѵ�.\r\n\r\n \r\n��� ���ܰ� ����� ���Ͽ� " +
        "������ ��Ƴ��ƾ��Ѵ�.\r\n\r\n\r\n\r\n����� ���.\r\n";



    void Start()
    {
        StartCoroutine(_typing());
   
    }

    // Update is called once per frame

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Gamestart();
        }
    }
    IEnumerator _typing()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0;i <= m_text.Length;i++)
        {
            tx.text = m_text.Substring(0, i);

            yield return new WaitForSeconds(0.1f);
        }
    }

    public void Gamestart()
    {
        SceneManager.LoadScene("Project Z map");
    }
}

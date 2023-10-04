using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class typeingEffect : MonoBehaviour
{

    public Text tx;
    private string m_text = "미래에 어느 날 당신이 눈을 뜬 아침. 세상의 모든 것이 변해 있었다." +
        " \r\n\r\n\r\n원인을 알 수 없는 바이러스 때문에 사람들은 미치광이로 변해갔고 " +
        "일부의 사람들은 좀비로 변하여\r\n주위의 모든 생명체를 공격하기 시작했다." +
        "\r\n\r\n\r\n도시의 모든 시스템은 멈춰버렸고 홀로 남은 당신은 어딘 가에 있을 생존자들을 " +
        "찾기 위해 끝까지 생존해야 한다.\r\n\r\n \r\n당신은 좀비의 공격을 막아내야 할 뿐 아니라 " +
        "배고픔, 갈증, 피로 와도 싸워 이겨내야 한다. \r\n\r\n\r\n어김없이 찾아오는 밤에는 당신의 " +
        "시야는 좁고 어둡게 되며 손전등에 의지하여 위험을 피할 수 밖에 없다.\r\n\r\n\r\n도시는 황폐화 " +
        "되었지만 다행히 건물 곳곳에서 총, 칼과 같은 무기와 식량, 물 등 생존에 필요한 물건들을 " +
        "획득할 수 있다. \r\n\r\n\r\n도시의 건물을 수색하여 생존에 필요한 아이템을 회득하고, " +
        "몰려드는 좀비를 피하거나 물리쳐야 한다.\r\n\r\n \r\n모든 수단과 방법을 다하여 " +
        "끝까지 살아남아야한다.\r\n\r\n\r\n\r\n행운을 빈다.\r\n";



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
